using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
   private void Update()
    {
        TimeSpeedValue();
    }
    public void TimeSpeedValue()
    {
        Time.timeScale = slider.value;
    }
}
