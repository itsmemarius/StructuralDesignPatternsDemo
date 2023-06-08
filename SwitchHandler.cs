using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace SwitchControl
{
    public class SwitchHandler : MonoBehaviour
    {
        int switchState = 1;
        public GameObject switchBtn;

        void OnSwitchButtonClicked()
        {
            switchBtn.transform.DOLocalMoveX(-switchBtn.transform.localPosition.x, 0.2f);
        }
        public int getSwitchState()
        {
            switchState = Math.Sign(-switchBtn.transform.localPosition.x);
            return this.switchState;
        }

    }
}