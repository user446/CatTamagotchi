using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public CatBehaviour behaviour;
    public CatMood mood;
    public Text moodText;
    public Text behaviourText;
    public Slider behaviourSlider;
    private Animator animator;
    private List<AnimationClip> clips = new List<AnimationClip>();
    private bool onBehaving;

    void Start()
    {
        animator = GetComponent<Animator>();
        clips.AddRange(animator.runtimeAnimatorController.animationClips);
        animator.Play(clips.Find(clip => clip.Equals(behaviour.playClip)).name);

        moodText.text = mood.description;
        behaviourText.text = behaviour.description;
    }

    public void GetPlayerAction(PlayerActions action)
    {
        Debug.Log("Action triggered: " + action.name);
        behaviour = action.GetBehaviourByMood(mood);

        behaviourText.text = behaviour.description;
        animator.Play(clips.Find(clip => clip.Equals(behaviour.playClip)).name);
        if(behaviour.audio != null)
            AudioSource.PlayClipAtPoint(behaviour.audio, Camera.main.transform.position, 0.5f);
        if(onBehaving == false)
            StartCoroutine(AwaitBeforeNewMood(Time.time + behaviour.lifeTime));
    }

    IEnumerator AwaitBeforeNewMood(float time)
    {
        onBehaving = true;
        behaviourSlider.minValue = Time.time;
        behaviourSlider.maxValue = time;
        while(Time.time < time)
        {
            Debug.Log("Waiting...");
            behaviourSlider.value = Time.time;
            yield return null;
        }
        mood = behaviour.triggerMood;
        behaviour = behaviour.triggerBehaviour;

        moodText.text = mood.description;
        behaviourText.text = behaviour.description;

        animator.Play(clips.Find(clip => clip.Equals(behaviour.playClip)).name);
        Debug.Log("Finished");
        onBehaving = false;
    }
}
