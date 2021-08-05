using System;

namespace series_crud
{
    public class Series : BaseEntity
    {
        private GenderEnum Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool Excluded { get; set; }

        public Series(int id, GenderEnum gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string _return = "";
            _return += "Gênero: " + this.Gender + Environment.NewLine;
            _return += "Título: " + this.Title + Environment.NewLine;
            _return += "Descrição: " + this.Description + Environment.NewLine;
            _return += "Ano: " + this.Year + Environment.NewLine;
            _return += "Excluido: " + this.Excluded;
            return _return;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        internal int returnId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.Excluded = true;
        }
    }
}