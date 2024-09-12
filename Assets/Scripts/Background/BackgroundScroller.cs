using UnityEngine;
using UnityEngine.UI;

namespace Background
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private RawImage _image;
        [SerializeField] private float _positionX;
    
        private void Update()
        {
            _image.uvRect = new Rect(_image.uvRect.position + new Vector2(_positionX, _image.uvRect.position.y) * Time.deltaTime, _image.uvRect.size);
        }
    }
}
