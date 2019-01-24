using System.ComponentModel;

namespace Core.Common.Views
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged(string propertyName)
        {
            /*if(PropertyChanged != null)
            {
                OnPropertyChanged(propertyName);
            }*/
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        /*public virtual void OnPropertyChanged(string propertyName)
        {
        }*/

        #endregion
    }
}
