using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoyconXRHandler : MonoBehaviour
{
    private List<Joycon> joycons;
    private JoyconXR leftJoyconXR;
    private JoyconXR rightJoyconXR;
    public XRDirectInteractor leftInteractor;
    public XRDirectInteractor rightInteractor;

    void Start()
    {
        // ��ȡ Joycon ʵ��
        joycons = JoyconManager.Instance.j;

        // ȷ������������ Joycon ����
        if (joycons.Count < 2)
        {
            Debug.LogError("��Ҫ�������� Joycon ����ʹ�� JoyconXR");
            return;
        }

        // ��ʼ�� JoyconXR ʵ��
        leftJoyconXR = new JoyconXR(joycons[0], leftInteractor);
        rightJoyconXR = new JoyconXR(joycons[1], rightInteractor);

        // ���� Start ����
        leftJoyconXR.Start();
        rightJoyconXR.Start();
    }

    void Update()
    {
        // ���� Update ����
        leftJoyconXR.Update();
        rightJoyconXR.Update();
    }

    void OnDestroy()
    {
        // ���� Stop ����
        if (leftJoyconXR != null)
        {
            leftJoyconXR.Stop();
        }
        if (rightJoyconXR != null)
        {
            rightJoyconXR.Stop();
        }
    }
}