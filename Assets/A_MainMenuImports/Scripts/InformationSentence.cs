using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationSentence : MonoBehaviour
{
    private TextMeshPro tmp;
    public string[] sentence;

    private void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        // "���� ���̽�ƽ���� ĳ���͸� ���� �����̼���!", "���⺯���� �Ʒ� ������â���� ���ϴ� ����� ���ð����մϴ�!", "��ž��ġ�� ���������ּ���!"
    }

    public void ChangeSentence()
    {

        tmp.text = sentence[Random.Range(0, sentence.Length + 1)];
    }
}