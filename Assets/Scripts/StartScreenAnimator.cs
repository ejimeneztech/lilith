using UnityEngine;
using UnityEngine.UI;

public class StartScreenAnimator : MonoBehaviour
{
    public Sprite[] frames;
    public float fps = 5f;
    private Image image;
    private int currentFrame;
    private float timer;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (frames.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= 1f / fps)
        {
            timer -= 1f / fps;
            currentFrame = (currentFrame + 1) % frames.Length;
            image.sprite = frames[currentFrame];
        }
    }
}
