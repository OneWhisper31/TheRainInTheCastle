using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : MonoBehaviour
{
    public static EntityFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static EntityFactory _instance;

    [SerializeField] int entityStock = 10;


    [Header("Prefabs")]
    [SerializeField] PlayerHealth cultivoPrefab;
    [SerializeField] PlayerHealth arqueroPrefab;
    [SerializeField] PlayerHealth piromanoPrefab;
    [SerializeField] PlayerHealth expertoPrefab;
    [SerializeField] EnemyHealth zombiePrefab;
    //[SerializeField] EnemyHealth kamikazePrefab;
    //[SerializeField] EnemyHealth blindadoPrefab;


    //objects pools
    public ObjectPool<PlayerHealth> poolCultivo ;
    public ObjectPool<PlayerHealth> poolArquero ;
    public ObjectPool<PlayerHealth> poolPiromano;
    public ObjectPool<PlayerHealth> poolExperto ;
    public ObjectPool<EnemyHealth> poolZombie  ;
    //public ObjectPool<EnemyHealth> poolKamikaze;
    //public ObjectPool<EnemyHealth> poolBlindado;



    void Awake()
    {
        _instance = this;

        //allays
        poolCultivo = new ObjectPool<PlayerHealth>(CultivoCreator, PlayerHealth.TurnOn, PlayerHealth.TurnOff, entityStock);
        poolArquero = new ObjectPool<PlayerHealth>(ArqueroCreator, PlayerHealth.TurnOn, PlayerHealth.TurnOff, entityStock);
        poolPiromano = new ObjectPool<PlayerHealth>(PiromanoCreator, PlayerHealth.TurnOn, PlayerHealth.TurnOff, entityStock);
        poolExperto = new ObjectPool<PlayerHealth>(ExpertoCreator, PlayerHealth.TurnOn, PlayerHealth.TurnOff, entityStock);

        //enemies
        poolZombie = new ObjectPool<EnemyHealth>(ZombieCreator, EnemyHealth.TurnOn, EnemyHealth.TurnOff, entityStock);
        //poolKamikaze = new ObjectPool<EnemyHealth>(KamikazeCreator, EnemyHealth.TurnOn, EnemyHealth.TurnOff, entityStock);
        //poolBlindado = new ObjectPool<EnemyHealth>(BlindadoCreator, EnemyHealth.TurnOn, EnemyHealth.TurnOff, entityStock);
    }

    //allays
    PlayerHealth CultivoCreator()
    {
        return Instantiate(cultivoPrefab);
    }
    PlayerHealth ArqueroCreator()
    {
        return Instantiate(arqueroPrefab);
    }
    PlayerHealth PiromanoCreator()
    {
        return Instantiate(piromanoPrefab);
    }
    PlayerHealth ExpertoCreator()
    {
        return Instantiate(expertoPrefab);
    }

    //enemies
    EnemyHealth ZombieCreator()
    {
        return Instantiate(zombiePrefab);
    }
    //EnemyHealth KamikazeCreator()
    //{
    //    return Instantiate(kamikazePrefab);
    //}
    //EnemyHealth BlindadoCreator()
    //{
    //    return Instantiate(blindadoPrefab);
    //}

    public void ReturnEntity(TypesOfEntitys type,Health b)
    {
        switch (type)
        {
            case TypesOfEntitys.Cultivo:
                poolCultivo.ReturnObject((PlayerHealth)b);
                break;
            case TypesOfEntitys.Arquero:
                poolArquero.ReturnObject((PlayerHealth)b);
                break;
            case TypesOfEntitys.Piromano:
                poolPiromano.ReturnObject((PlayerHealth)b);
                break;
            case TypesOfEntitys.Experto:
                poolExperto.ReturnObject((PlayerHealth)b);
                break;
            case TypesOfEntitys.Zombie:
                poolZombie.ReturnObject((EnemyHealth)b);
                break;
            //case TypesOfEntitys.Kamikaze:
            //    poolKamikaze.ReturnObject((EnemyHealth)b);
            //    break;
            //case TypesOfEntitys.Blindado:
            //    poolBlindado.ReturnObject((EnemyHealth)b);
            //    break;
            default:
                break;
        }
    }
}
public enum TypesOfEntitys
{
    Vacio,//Usado en grid para definir cuando una celda es nula
    Cultivo,
    Arquero,
    Piromano,
    Experto,
    Zombie,
    Kamikaze,
    Blindado
}
