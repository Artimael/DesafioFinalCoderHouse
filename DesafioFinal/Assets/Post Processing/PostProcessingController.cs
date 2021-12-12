using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    private PostProcessVolume globalVolume;

    void Awake(){
        globalVolume = GetComponent<PostProcessVolume>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.onDamageChange +=statusColorEffect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void statusColorEffect(bool status){
        ColorGrading colorFx;
        globalVolume.profile.TryGetSettings(out colorFx);
        colorFx.active = status;
    }
}
