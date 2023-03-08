using Entitas;
using UnityEngine;

public class LandedListener : MonoBehaviour, IEventListener, ILandedListener
{
	public GameObject EffectPrefab;

    AudioSource AudioPlayer;
    private void Awake()
    {
        AudioPlayer = GameObject.FindGameObjectWithTag("OnGroundSound").GetComponent<AudioSource>();
    }

    public void RegisterListeners(IEntity entity)
	{
		var e = Contexts.sharedInstance.gameState.CreateEntity();
		e.AddLandedListener(this);
	}

	public void OnLanded(GameStateEntity entity)
	{
		var go = Instantiate(EffectPrefab, transform.position, Quaternion.identity);
		Destroy(go, 5f);
        AudioPlayer.PlayOneShot(AudioPlayer.clip);

    }
}
