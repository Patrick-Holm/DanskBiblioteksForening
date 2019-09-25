using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Repository;

namespace BIZ
{
    public class ClassBiz : ClassNotify
    {
        private ObservableCollection<ClassBog> _boeger;
        private ObservableCollection<ClassBog> _laanteBoeger;
        private ClassBog _bog;
        private ClassDbfDB DbFDB = new ClassDbfDB();
        public void classBIZ()
        {

        }

        public ObservableCollection<ClassBog> boeger
        {
            get { return _boeger; }
            set { _boeger = value; }
        }
        public ObservableCollection<ClassBog> laanteBoeger
        {
            get { return _laanteBoeger; }
            set { _laanteBoeger = value; }
        }

        public ClassBog bog
        {
            get { return _bog; }
            set
            {
                if (value != _bog)
                {
                    _bog = value;
                    Notify("bog");
                }
            }
        }


        private ClassPerson _person;

        public ClassPerson person
        {
            get { return _person; }
            set
            {
                if (value != _person)
                {
                    _person = value;
                    Notify("person");
                }
            }
        }
        public void SubmitThisBookToTheLibrary(int bogID, int personID)
        {

        }
        public void LendThisBookToTheUser(ClassBog id, ClassPerson personID)
        {

        }
        public ObservableCollection<ClassBog> GetAllLentBooks(ClassPerson id)
        {
            return DbFDB.GetAllBooksLentToUser(id, "1");
        }
        public ObservableCollection<ClassBog> GetAllBooksWhereTheTitleContainsTheseWords(string words)
        {
            return DbFDB.GetAllBooksLike(words);
        }
        public bool CheckForDobuleLending(ClassBog bog)
        {

        } 
    }
}
