using Entitas;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class DeathListener : MonoBehaviour, IEventListener, IDeadListener
{
    public GameObject EffectPrefab;

    AudioSource AudioPlayer;
    private void Awake()
    {
        AudioPlayer = GameObject.FindGameObjectWithTag("DeathSound").GetComponent<AudioSource>();
    }

    public void RegisterListeners(IEntity entity)
    {
        var player = (GameEntity)entity;
        player.AddDeadListener(this);
    }

    public async void OnDead(GameEntity entity)
    {
        AudioPlayer.PlayOneShot(AudioPlayer.clip);
        var go = Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(go, 5f);

        SaveScript.IsDead = true;
        if (SaveScript.MaximumScore < SaveScript.CurrentScore)
        {
            SaveScript.MaximumScore = SaveScript.CurrentScore;
            SaveSystem.SaveMaxmimumScore(new ScoreData(SaveScript.MaximumScore));
        }
        await Task.Delay(2500);
        SaveScript.IsDead = false;
        SaveScript.CurrentScore = 0;
    }
}