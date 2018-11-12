using System.Collections;
using PSPUtil.Singleton;
using PSPUtil.StaticUtil;
using UnityEngine;


namespace PSPUtil.Control
{
    public class Ctrl_Coroutine : Singleton_Mono<Ctrl_Coroutine>
    {

        public void SetActiveFalseInTime(GameObject go,float timer)
        {
            if (!go.activeSelf)
            {
                MyLog.Red("已经是非激活状态了");
                return;
            }
            StartCoroutine(StartTimer(go,timer,false));
        }


        public void SetActiveTureInTime(GameObject go, float timer)
        {
            if (go.activeSelf)
            {
                MyLog.Red("已经是激活状态了");
                return;
            }
            StartCoroutine(StartTimer(go, timer, true));
        }



        IEnumerator StartTimer(GameObject go, float timer,bool isActive)
        {
            yield return new WaitForSeconds(timer);
            go.SetActive(isActive);
        }

    }





}

