using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
namespace ForexModel
{
    public class ForexObservableData : INotifyPropertyChanged
    {


        private string curCode { get; set; }

        public string CurCode
        {
            get { return curCode; }
            set
            {
                this.curCode = value;
                NotifyPropertyChanged("CurCode");
            }
        }


        public string TranType { get; set; }


        public int Refno { get; set; }

        public decimal FxAmnt { get; set; }


        public decimal Rate { get; set; }

        public decimal EquvAmnt { get; set; }
        public decimal Profit { get; set; }
        public decimal AvgRate { get; set; }
        public decimal CostRate { get; set; }

        public string MinMax { get; set; }



#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
