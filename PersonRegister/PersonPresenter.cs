using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister
{
    public class PersonPresenter
    {
        IPerson _model;
        IDataView _form;
        public PersonPresenter() { }

        public PersonPresenter(IPerson model, IDataView form)
        {
            _model = model;
            _form = form;
            _form.SaveData += new EventHandler<EventArgs>(OnSave);
            _form.LoadData += new EventHandler<EventArgs>(OnLoad);
        }

        private void OnSave(object sender, EventArgs e)
        {
            _model.Name = _form.PersonName;
            _model.Age = _form.Age;
            _model.Save();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            string res = _model.Load();
            string[] dataArr = res?.Split('\n');
            for(int i = 0; i < dataArr.Length-1; i+=2)
            {
                if (dataArr[i] == _form.Search)
                {
                    _form.Search = "Name: "+dataArr[i]+ " | Age: " + dataArr[i+1];
                    _form.Age = Convert.ToInt16( dataArr[i + 1]);
                    _form.PersonName = dataArr[i];
                }
            }
            UpdateModel();
        }

        private void UpdateModel()
        {
            _model.Age = _form.Age;
            _model.Name = _form.PersonName;
        }
    }
}
