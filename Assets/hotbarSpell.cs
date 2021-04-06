using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hotbarSpell : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    public hotbarConfig hotbar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (hotbar != null)
        {
            if (Input.GetKeyDown(hotbar.HotKey))
            {
                Debug.Log("Spell Castada por: " + hotbar.name);
            }

        }

    }

    // Pick and Drop

    [Header("Sistema de pega os objetos")]

    [SerializeField] private Canvas canvas;
   
    private RectTransform rectTrasform;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        if (gameObject.GetComponent<CanvasGroup>() != null)
        {
            this.gameObject.AddComponent<CanvasGroup>();
        }

        rectTrasform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //  Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //   Debug.Log("onDrag");
        rectTrasform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //   Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

}