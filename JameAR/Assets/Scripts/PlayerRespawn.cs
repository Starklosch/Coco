using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]
    ParticleSystem respawnParticles;

    static PlayerRespawn _instance;
    public static PlayerRespawn Instance
    {
        get => _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;

        Respawn();
    }

    public void Respawn()
    {
        if (InteractionManager.Instance == null)
            return;

        if (InteractionManager.Instance.IsSoul && Checkpoint.ActiveHell != null)
            transform.position = Checkpoint.ActiveHell.transform.position;
        else if (!InteractionManager.Instance.IsSoul && Checkpoint.ActiveMortal != null)
            transform.position = Checkpoint.ActiveMortal.transform.position;
        //var ck = FindObjectsOfType<Checkpoint>();
        //if (InteractionManager.Instance.IsSoul)
        //    foreach (var item in ck)
        //    {
        //        if(item.Type == Checkpoint.CheckpointType.Hell)
        //        {
        //            transform.position = item.transform.position;
        //            break;
        //        }
        //    }
        //else
        //    foreach (var item in ck)
        //    {
        //        if (item.Type == Checkpoint.CheckpointType.Mortal)
        //        {
        //            transform.position = item.transform.position;
        //            break;
        //        }
        //    }

        respawnParticles.Play();
    }

    public void Death()
    {

    }
}
