using UnityEngine;

public class MapController : MonoBehaviour
{
    #region Fields and Properties

    /// <summary>
    /// THERE CAN BE ONLY ONE
    /// </summary>
    public static MapController mapController;

    //size of the map in units/positions
    public int width, height;



    #endregion

    #region Methods

    void Start()
    {
        //THERE CAN BE ONLY ONE
        if (mapController != null && mapController != this)
        {
            Destroy(this.gameObject);
            return;
        }
        mapController = this;
    }

    #endregion
}
