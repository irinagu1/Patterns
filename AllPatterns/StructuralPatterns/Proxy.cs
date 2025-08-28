using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    public class ProxyClient 
    {
        public void Show()
        {
            IYouTube youTube = new ProxyYouTube();
            youTube.getVideoInfo(1);
            youTube.getVideoInfo(2);
            youTube.getVideoInfo(1);

            youTube.downloadVideo(4);
            youTube.downloadVideo(4);
        }
    }

    public interface IYouTube
    {
        
        void getVideoInfo(int id);
        void downloadVideo(int id);
    }

    public class RealYouTube : IYouTube
    {
        public void downloadVideo(int id)
        {
            Console.WriteLine($"Downloading id: {id}");
        }

        public void getVideoInfo(int id)
        {
            Console.WriteLine($"Video info get: {id}");
        }
    }

    public class ProxyYouTube : IYouTube
    {
        private List<int> _cahced;
        private Lazy<RealYouTube> _lazyRealYouTube;

        public ProxyYouTube()
        {
            _cahced = new List<int>();
            _lazyRealYouTube = new Lazy<RealYouTube>();
        }

        public void downloadVideo(int id)
        {
            if (_cahced.Contains(id))
                Console.WriteLine($"Downloading from cache {id}");
            else
            {
                _cahced.Add(id);
                _lazyRealYouTube.Value.downloadVideo(id);
            }
        }

        public void getVideoInfo(int id)
        {
            if (_cahced.Contains(id))
                Console.WriteLine($"Video info get from cache {id}");
            else
            {
                _cahced.Add(id);
                _lazyRealYouTube.Value.getVideoInfo(id);
            }

        }
    }
}
