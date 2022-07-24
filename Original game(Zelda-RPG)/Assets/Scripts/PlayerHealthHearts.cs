using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{

    public class PlayerHealthHearts : MonoBehaviour
    {
        public Sprite FullHeart,ThreeFourthsHeart,HalfHeart,QuarterHeart,EmptyHeart;
        Image HeartImage;

        public void Awake()
        {
            HeartImage = GetComponent<Image>();
        }

        public void SetHeartImage(HeartStatus status)
        {
            switch (status)
            {
                case HeartStatus.Empty:
                    HeartImage.sprite = EmptyHeart;
                break;

                case HeartStatus.Quarter:
                    HeartImage.sprite = QuarterHeart;
                break;

                case HeartStatus.Half:
                    HeartImage.sprite = HalfHeart;
                break;

                case HeartStatus.ThreeFourths:
                    HeartImage.sprite = ThreeFourthsHeart;
                break;

                case HeartStatus.Full:
                    HeartImage.sprite = FullHeart;
                break;

            }
        }

    
    }

    public enum HeartStatus
    {
        Empty = 0,
        Quarter = 1,
        Half = 2,
        ThreeFourths = 3,
        Full = 4,

    }

}



