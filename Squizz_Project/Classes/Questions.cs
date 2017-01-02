using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squizz_Project.Classes
{
    public class Questions : System.Collections.ObjectModel.ObservableCollection<Question>
    {
        public Questions(params Question[] values)
        {
            //Add(new Question(1, "Dishonored", "ms-appx://Squizz_Project/Assets/GamePicture/dishonored.jpg", 1));
            //Add(new Question(2, "Scott Pilgrim The Game", "ms-appx://Squizz_Project/Assets/GamePicture/scott.jpg", 2));
        }
    }
}
