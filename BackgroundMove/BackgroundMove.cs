using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private float offset = 50f;
    [SerializeField] GameObject[] layer0_Imgs;  //배경 1, 2의 0.png 파일
    [SerializeField] GameObject[] layer1_Imgs;  //배경 1, 2의 1.png 파일
    [SerializeField] GameObject[] layer2_Imgs;  //배경 1, 2의 2.png 파일
    [SerializeField] GameObject[] layer3_Imgs;  //배경 1, 2의 3.png 파일
    [SerializeField] GameObject[] layer4_Imgs;  //배경 1, 2의 4.png 파일
    [SerializeField] GameObject[] layer5_Imgs;  //배경 1, 2의 5.png 파일
    [SerializeField] GameObject[] layer6_Imgs;  //배경 1, 2의 6.png 파일
    [SerializeField] float[] moveSpeeds;

    private void Update()
    {
        ImageMove(layer0_Imgs, moveSpeeds[0]);         //이미지 오브젝트와 이미지 이동 속도 입력
        ImageMove(layer1_Imgs, moveSpeeds[0]);
        ImageMove(layer2_Imgs, moveSpeeds[0]);
        ImageMove(layer3_Imgs, moveSpeeds[0]);
        ImageMove(layer4_Imgs, moveSpeeds[1]);
        ImageMove(layer5_Imgs, moveSpeeds[1]);
        ImageMove(layer6_Imgs, moveSpeeds[2]);
    }

    public void ImageMove(GameObject[] img, float speed)
    {
        img[0].transform.position = new Vector3(img[0].transform.position.x + -1f * Time.deltaTime * speed, 0f, 0f);    //x축을 기준으로 좌측으로 이동, -1f는 x축 이동 방향
        img[1].transform.position = new Vector3(img[1].transform.position.x + -1f * Time.deltaTime * speed, 0f, 0f);


        if (img[0].transform.position.x <= -offset)     //배경 이미지가 배경 길이 만큼(offset) 이동하면 다음 배경 뒤에 붙이기
        {
            img[0].transform.position = new Vector3(img[1].transform.position.x + offset, 0f, 0f);
        }

        if (img[1].transform.position.x <= -offset)
        {
            img[1].transform.position = new Vector3(img[0].transform.position.x + offset, 0f, 0f);
        }
    }
}
