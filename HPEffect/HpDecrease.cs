using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDecrease : MonoBehaviour
{
    //RectTransform Width를 조절하기 위해 자료형을 RectTransform으로 가져온다
    [SerializeField] RectTransform HPBackground; //회색 HP 배경
    [SerializeField] RectTransform baseImg;      //현재 HP 바(빨강)
    [SerializeField] RectTransform damagedImg;   //감소 효과를 보여주는 이미지(Cyan)

    bool isDamaged = false;  //데미지를 입어 감소 효과를 보여주고 있는지를 확인
    bool isBaseImgDecreased = false; //현재 HP바가 데미지에 의해 줄어들었는지 확인

    float damage = 0f;           //데미지 감소 크기
    float decreaseSpeed = 100f;  //Cyan 이미지가 줄어드는 속도

    float currentTime = 0f; //데미지를 받는 시점의 시작 시간
    float delayTime = 1f;   //딜레이 시간, 임의로 1초로 정했다

    private void Awake()
    {
        //시작 시 기본값 설정, 앞서서 width height를 각각 400, 100으로 지정했다면 없어도 무방
        baseImg.sizeDelta = new Vector2(HPBackground.rect.width, baseImg.rect.height);
        damagedImg.sizeDelta = new Vector2(HPBackground.rect.width, damagedImg.rect.height);
    }

    
    void Update()
    {
        if (isDamaged)
        {
            if (!isBaseImgDecreased)
            {
                //RectTransform에서 width, height는 *.sizeDelta = new Vector2() 형식으로 변경한다
                //또한 현재 width, height값은 *.rect.width/height를 통해 받아올 수 있다.
                //기본 HP바는 데미지를 입을 때마다 한 번 발생한다
                baseImg.sizeDelta = new Vector2(baseImg.rect.width - damage, baseImg.rect.height);
                isBaseImgDecreased = true;
            }

            // 데미지를 받은 시점부터 시간을 쟤며 delayTime이 되면 감소 효과를 시작한다
            if (currentTime < delayTime)
            {
                currentTime += Time.deltaTime;
            } else {

                //cyan 이미지의 너비가 기본 HP바 너비보다 작아질 때까지 Update한다
                if (baseImg.rect.width < damagedImg.rect.width)
                {
                    damagedImg.sizeDelta = new Vector2(damagedImg.rect.width - decreaseSpeed * Time.deltaTime, damagedImg.rect.height);
                }
                else
                {
                    //cyan 이미지는 Time.deltaTime에 의해 기본 이미지보다 근소하게 더 작아 이를 같게 수정
                    //너비가 같아졌으므로 감소 효과를 종료하며 currentTime을 초기화한다.
                    damagedImg.sizeDelta = new Vector2(baseImg.rect.width, damagedImg.rect.height);
                    isDamaged = false;
                    currentTime = 0f;
                }
            }
        }
    }

    //버튼 클릭 메소드
    public void GetDamaged()
    {
        //데미지 무작위 부여 및 HP 감소 효과 활성화
        damage = Random.Range(10f, 100f);
        isDamaged = true;
        isBaseImgDecreased = false;
    }
}
