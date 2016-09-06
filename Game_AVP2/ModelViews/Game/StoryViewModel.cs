using Game_AVP2.Models.Avp2.GameModels.Tables;

namespace Game_AVP2.ModelViews.Game
{
    public class StoryViewModel
    {
        public int StoryId { get; set; }
        public string Text { get; set; }
        public bool IsBattle { get; set; }
        public int NextText { get; set; }
        public bool IsDialogue { get; set; }
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }

        public StoryViewModel(Story story)
        {
            //StoryId = story.StoryId; -dont need in ui
            Text = story.Text;
            IsBattle = story.IsBattle;
            IsDialogue = story.IsDialogue;
            IsFirst = story.IsFirst;
            IsLast = story.IsLast;
            if(story.NextText != null && story.IsLast != true)
            {
                NextText = (int)story.NextText;
            }

            
        }
    }
}