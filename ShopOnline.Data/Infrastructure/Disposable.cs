

using System;
namespace ShopOnline.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;


        //How can we dispose object or entity in c# in program

        // ANSWER:
        // -  Dispose is just a handy place to close files, network connections, SQL server connections, etc. 

        // ************  It doesn't free memory


        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            //GC STANDS FOR GARBAGE COLLECTION
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }
}
