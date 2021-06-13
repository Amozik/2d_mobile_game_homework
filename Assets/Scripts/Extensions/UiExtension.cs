using UnityEngine.UI;

namespace MobileGame.Extensions
{
    public static class UiExtension
    {
        public static void SetTransparency(this Image pImage, float pTransparency)
        {
            if (pImage == null) return;
            
            var alpha = pImage.color;
            alpha.a = pTransparency;
            pImage.color = alpha;
        }
    }
}