using UnityEngine;
using UnityEngine.UI;

namespace Background
{
    public class BgScroller : MonoBehaviour
    {
        [SerializeField] private RawImage _image;
        [SerializeField] private float _x;
    
        private void Update()
        {
            _image.uvRect = new Rect(_image.uvRect.position + new Vector2(_x, _image.uvRect.position.y) * Time.deltaTime, _image.uvRect.size);
        }
    }
}
