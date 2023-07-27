using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin_Chooser : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private List<RuntimeAnimatorController> newController = new List<RuntimeAnimatorController>();

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        int skinNo = PlayerPrefs.GetInt("skinIndex");
        anim.runtimeAnimatorController = newController[skinNo];
    }
}
