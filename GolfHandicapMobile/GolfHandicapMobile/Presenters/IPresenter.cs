namespace GolfHandicapMobile.Presenters
{
    using System.Threading.Tasks;

    public interface IPresenter
    {
        #region Methods

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns></returns>
        Task Start();

        #endregion
    }
}