using Entities;

namespace CoreWeb.Models
{
    public class HomePageViewModel
    {
        public List<Category>? Categories { get; set; }
        public List<Slider>? Sliders { get; set; }
        public List<News>? News { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
