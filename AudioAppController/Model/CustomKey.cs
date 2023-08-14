using System.Collections.Generic;

namespace AudioAppController.Model
{
    public class CustomKey
    {
        public string RealName { get; private set; }
        public string DisplayName { get; private set; }

        public CustomKey(string realName, string displayName)
        {
            DisplayName = displayName;
            RealName = realName;
        }

        public void ChangeKey(CustomKey customKey)
        {
            this.RealName = customKey.RealName;
            this.DisplayName = customKey.DisplayName;
        }

        public override bool Equals(object obj)
        {
            return obj is CustomKey key &&
                   RealName == key.RealName;
        }
        public override int GetHashCode()
        {
            return 1930161422 + EqualityComparer<string>.Default.GetHashCode(RealName);
        }
    }
}
