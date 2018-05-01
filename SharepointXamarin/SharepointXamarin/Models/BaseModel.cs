using System;
namespace SharepointXamarin.Models
{
    public class BaseModel
    {
        public bool IsCorrect { get; set; }
        public string MsgError { get; set; }

        public BaseModel(){
            this.MsgError = "Error...";
        }
    }
}
