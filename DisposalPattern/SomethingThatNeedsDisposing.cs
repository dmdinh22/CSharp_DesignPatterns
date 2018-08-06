using System;
using System.IO;

namespace CSharp_DesignPatterns.Disposable
{
    public sealed class SomethingThatNeedsDisposing : IDisposable
    {
        private readonly Stream stream;

        public void Dispose()
        {
            stream.Dispose();
        }
    }
}