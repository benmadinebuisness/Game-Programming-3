using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomLife : MonoBehaviour
{
    /// <summary>
    ///  This class manages what happens when the mushroom dies and how long it takes to die.
    /// </summary>

    #region Mushroom Death/Life 
        //The mushroom minum and maximum amount of life, the _ActualLife is a random value inbetween. The death time, is how long the mushroom takes to die when requirements are met.
    private float _MinMushroomLife = 10f, _MaxMushroomLife = 30f;
    [HideInInspector]
    public float _ActualLife; public float _OriginalLife;
    private float _DeathTime = 5f;
    #endregion

    #region Mushroom Scale
        //Original mushroom scale.
    private Vector3 _MushroomOrignalScale;
    #endregion

    #region Singleotn
    public static MushroomLife _MushroomLife;
    #endregion

    public bool _IsPoison { get; private set; }

    private void Awake()
    {
        _MushroomLife = this;
    }

    private void Start ()
    {
        MushroomOriginalScale();
        LifeSpan();
	}

    private void Update()
    {
        //Decreases the life of the mushroom over time.
        _ActualLife -= Time.deltaTime;
        //Once life is below or equal to zero then call the methods and destroy the object.
        if (_ActualLife <= 0)
        {
            MushroomRise();
            MushroomShrink();
            Destroy(gameObject, _DeathTime);
        }
        //Check if poisen
        if (_ActualLife <= _OriginalLife / 2)
        {
            _IsPoison = true;
        }
    }

    private void MushroomOriginalScale()
    {
        //Sets the mushrooms original scale.
        _MushroomOrignalScale = transform.localScale;
    }

    private void LifeSpan()
    {
        //Sets the mushrooms actual life span from a random number between min and max life.
        _ActualLife = Random.Range(_MinMushroomLife, _MaxMushroomLife);
        _OriginalLife = _ActualLife;
    }

    private void MushroomRise()
    {
        //Simply moves the mushroom up on the y axis over time.
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
    }

    private void MushroomShrink()
    {
        //Sets the mushroom scale to the vector returned from ScaleLerp();
         transform.localScale = ScaleLerp();
    }

    private Vector3 ScaleLerp()
    {
        //Creates a new vector.
        Vector3 scaleVector;
        //Lerps between the current scale size of the mushroom to the original scale size divided by two so size is reduced by 50% over time.
        scaleVector = Vector3.Lerp(transform.localScale, _MushroomOrignalScale / 2, 0.5f * Time.deltaTime);
        //Returns the vector.
        return scaleVector;
    }
}
