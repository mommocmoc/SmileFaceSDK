/*************************************************************************
*
* ILLUNI CONFIDENTIAL
* __________________
*
*  [2018] Illuni Incorporated
*  All Rights Reserved.
*
* NOTICE:  All information contained herein is, and remains
* the property of Illuni Incorporated and its suppliers,
* if any.  The intellectual and technical concepts contained
* herein are proprietary to Illuni Incorporated
* and its suppliers and may be covered by Republic of Korea, U.S. and Foreign Patents,
* patents in process, and are protected by trade secret or copyright law.
* Dissemination of this information or reproduction of this material
* is strictly forbidden unless prior written permission is obtained
* from Illuni Incorporated.
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCVCompact;

namespace FaceAnalyzer
{
    public class ExtraFunction
    {
        //입 움직임 감지 기능 스위치
        public bool initMouthMovementDetectOrNot = true;
        List<float> lipDistValues_Series;
        List<KeyValuePair<int, int>> lipIndexPairs = new List<KeyValuePair<int, int>>();
        List<float> lipDistWeight = new List<float>();
        int lndmrk_mode_0_1_offset = 33;
        float lipMovementDistDiff;
        public bool mouthMovementOrNot = false;

        public ExtraFunction()
        {
            InitMouthMovementDetection();
        }

        public void InitMouthMovementDetection()
        {
            lipDistValues_Series = new List<float>();

            lipIndexPairs = new List<KeyValuePair<int, int>>();
            lipIndexPairs.Add(new KeyValuePair<int, int>(32, 42));
            lipIndexPairs.Add(new KeyValuePair<int, int>(34, 40));
            lipIndexPairs.Add(new KeyValuePair<int, int>(36, 38));

            lipIndexPairs.Add(new KeyValuePair<int, int>(44, 50));
            lipIndexPairs.Add(new KeyValuePair<int, int>(45, 49));
            lipIndexPairs.Add(new KeyValuePair<int, int>(46, 48));

            lipIndexPairs.Add(new KeyValuePair<int, int>(34, 31));
            lipIndexPairs.Add(new KeyValuePair<int, int>(34, 37));

            lipIndexPairs.Add(new KeyValuePair<int, int>(40, 31));
            lipIndexPairs.Add(new KeyValuePair<int, int>(40, 37));
            
            lipDistWeight = new List<float>();
            lipDistWeight.Add(1.0f);
            lipDistWeight.Add(1.0f);
            lipDistWeight.Add(1.0f);

            lipDistWeight.Add(1.3f);
            lipDistWeight.Add(1.3f);
            lipDistWeight.Add(1.3f);

            lipDistWeight.Add(1.0f);
            lipDistWeight.Add(1.0f);

            lipDistWeight.Add(1.0f);
            lipDistWeight.Add(1.0f);

            initMouthMovementDetectOrNot = true;
        }


        public int DetectMouthMovement(int lndmrkMode, OpenCVCompact.Mat lndmrk)
        {
            if(initMouthMovementDetectOrNot == true)
            {
                float lipPairsDistance = 0;

                //Normalize Value
                float lipThickness = 0;
                if (lndmrkMode == 0)
                {
                    lipThickness = lipThickness + (float)Math.Sqrt((lndmrk.get(0, 34)[0] - lndmrk.get(0, 45)[0]) * (lndmrk.get(0, 34)[0] - lndmrk.get(0, 45)[0]) + (lndmrk.get(1, 34)[0] - lndmrk.get(1, 45)[0]) * (lndmrk.get(1, 34)[0] - lndmrk.get(1, 45)[0]));
                    lipThickness = lipThickness + (float)Math.Sqrt((lndmrk.get(0, 49)[0] - lndmrk.get(0, 40)[0]) * (lndmrk.get(0, 49)[0] - lndmrk.get(0, 40)[0]) + (lndmrk.get(1, 49)[0] - lndmrk.get(1, 40)[0]) * (lndmrk.get(1, 49)[0] - lndmrk.get(1, 40)[0]));
                }
                else
                {
                    lipThickness = lipThickness + (float)Math.Sqrt((lndmrk.get(0, 34 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(0, 45 + lndmrk_mode_0_1_offset)[0]) * (lndmrk.get(0, 34 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(0, 45 + lndmrk_mode_0_1_offset)[0]) + (lndmrk.get(1, 34 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(1, 45 + lndmrk_mode_0_1_offset)[0]) * (lndmrk.get(1, 34 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(1, 45 + lndmrk_mode_0_1_offset)[0]));
                    lipThickness = lipThickness + (float)Math.Sqrt((lndmrk.get(0, 49 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(0, 40 + lndmrk_mode_0_1_offset)[0]) * (lndmrk.get(0, 49 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(0, 40 + lndmrk_mode_0_1_offset)[0]) + (lndmrk.get(1, 49 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(1, 40 + lndmrk_mode_0_1_offset)[0]) * (lndmrk.get(1, 49 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(1, 40 + lndmrk_mode_0_1_offset)[0]));
                }
                lipThickness = lipThickness / 2;

                //Distance
                for (int i = 0; i < lipIndexPairs.Count; i++)
                {
                    int idx_0 = lipIndexPairs[i].Key;
                    int idx_1 = lipIndexPairs[i].Value;

                    float dist = 0;
                    if (lndmrkMode == 0)
                    {
                        dist = lipDistWeight[i] * (float)Math.Sqrt((lndmrk.get(0, idx_0)[0] - lndmrk.get(0, idx_1)[0]) * (lndmrk.get(0, idx_0)[0] - lndmrk.get(0, idx_1)[0]) + (lndmrk.get(1, idx_0)[0] - lndmrk.get(1, idx_1)[0]) * (lndmrk.get(1, idx_0)[0] - lndmrk.get(1, idx_1)[0])) / lipThickness;
                    }
                    else
                    {
                        dist = lipDistWeight[i] * (float)Math.Sqrt((lndmrk.get(0, idx_0 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(0, idx_1 + lndmrk_mode_0_1_offset)[0]) * (lndmrk.get(0, idx_0 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(0, idx_1 + lndmrk_mode_0_1_offset)[0]) + (lndmrk.get(1, idx_0 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(1, idx_1 + lndmrk_mode_0_1_offset)[0]) * (lndmrk.get(1, idx_0 + lndmrk_mode_0_1_offset)[0] - lndmrk.get(1, idx_1 + lndmrk_mode_0_1_offset)[0])) / lipThickness;
                    }
                    lipPairsDistance = lipPairsDistance + dist;
                }

                //Angle

                lipPairsDistance = lipPairsDistance / lipIndexPairs.Count;


                int nbOfPrevData = 3;
                if (lipDistValues_Series.Count < nbOfPrevData)
                {
                    lipDistValues_Series.Add(lipPairsDistance);
                }
                else
                {
                    lipDistValues_Series.RemoveAt(0);
                    lipDistValues_Series.Add(lipPairsDistance);
                }

                float meanPreviousDistValue = 0;
                for (int i = 0; i < lipDistValues_Series.Count - 1; i++)
                {
                    meanPreviousDistValue = meanPreviousDistValue + lipDistValues_Series[i];
                }
                meanPreviousDistValue = meanPreviousDistValue / (lipDistValues_Series.Count - 1);

                lipMovementDistDiff = lipDistValues_Series[lipDistValues_Series.Count - 1] - meanPreviousDistValue;
                //UnityEngine.Debug.Log("meanPreviousDistValue: " + meanPreviousDistValue + "  lipDistValue: " + lipDistValues_Series[lipDistValues_Series.Count - 1] + "  lipMovementDistDiff: " + lipMovementDistDiff);

                if(Math.Abs(lipMovementDistDiff) > 0.40)
                {
                    mouthMovementOrNot = true;
                }
                else
                {
                    mouthMovementOrNot = false;
                }
                return 1;
            }
            else
            {
                mouthMovementOrNot = false;
                return -1;
            }
        }
    }
}
