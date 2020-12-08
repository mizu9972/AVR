using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textscript : MonoBehaviour
{
    //　読み込んだテキストを出力するUIテキスト(text1
    [SerializeField]
    private TextMesh meshText1;
    //　読み込んだテキストを出力するUIテキスト(text2
    [SerializeField]
    private TextMesh meshText2;
    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset;
    //　テキストファイルから読み込んだデータ
    private string loadText1;
    ////　分割文字(-)で分割して配列に入れる
    private string[] splitText1;
    ////　現在表示中テキスト番号
    private int textNum1;
    //空白入力用
    string o = ("　");
    //区切り文字までの文字数取得用
    int num;

    void Start()
    {

        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("-"));
        textNum1 = 0;
        //テキスト内の文字空白で初期化
        meshText1.text = "";
        meshText2.text = "";

        //最終字(z)までのループ処理
        for (int i = 0; splitText1[textNum1] != "z"; i++)
        {
            //文字数取得
            num = splitText1[textNum1].Length;

            //構造偶数値
            if (textNum1 % 2 == 0)
            {
                sou(meshText1, meshText2);
            }
            //構造奇数値
            else
            {
                sou(meshText2, meshText1);
            }
            textNum1++;
        }
    }

    private void sou(TextMesh oetext,TextMesh twtext)
    {
        //テキスト1に文字列挿入
        oetext.text += splitText1[textNum1];
        //改行までを一つの要素にする
        string[] ensplitText;
        ensplitText = splitText1[textNum1].Split(char.Parse("\n"));

        //numで取得した文字数分のループ                  
        for (int m = 0; 0 < num; m++)
        {
            //一行の文字数取得
            int num2 = ensplitText[m].Length;

            //配列数未満の場合改行がある
            if (ensplitText.Length - 1 > m)
            {
                //改行を除いた分の文字数だけ空白入力
                for (int l = 0; l <= num2 - 2; l++)
                {
                    twtext.text += o;
                    num--;
                }
                //改行しその分文字数を減らすウ
                twtext.text += "\n";
                num--;
                num--;
            }
            else
            {
                //最終配列は改行を含まないので残り文字数分空白入力
                for (int l = 0; l <= num2; l++)
                {
                    if (num > 0)
                    {
                        twtext.text += o;
                        num--;
                    }
                }

            }
        }

    }
    //void Update()
    //{
    //    //1ループ分だけ処理するよう
    //    if (textNum1 == 0)
    //    {

    //    }
    //}

}
