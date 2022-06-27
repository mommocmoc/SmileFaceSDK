# SmileFaceSDK

<div id="top"></div>
<!--
*** 템플릿 잘 사용해서 일부러 문서에 남겨두었습니다.
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
<!-- [![Contributors][contributors-shield]][contributors-url] -->
[![License][license-shield]][license-url]

[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
<!-- [![MIT License][license-shield]][license-url] -->

<!-- [![LinkedIn][linkedin-shield]][linkedin-url] -->



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/mommocmoc/SmileFaceSDK">
    <img src="https://d2x8kymwjom7h7.cloudfront.net/live/application_no/119001/application_no/119001/images/%EC%9B%83%EC%83%81..png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">SmileFace SDK</h3>

  <p align="center">
    키보드, 마우스, 여러 콘솔들의 컨트롤러는 우리의 손에 최적화되어 설계되어있습니다. 하지만 여러 이유로 모두가 컨트롤러로 게임을 원활히 즐길 수 있지는 않습니다.
    Unity게임 엔진을 위한 패키지로 쉽게 얼굴 움직임과 표정으로 게임을 즐길 수 있게 해주는 개발 키트를 활용해, 더 많은 사람들을 즐겁게 만들어보면 어떨까요?
    <br />
    <a href="https://github.com/mommocmoc/SmileFaceSDK"><strong> 자세히 살펴보기 »</strong></a>
    <br />
    <br />
    <a href="https://indie.onstove.com/ko/games/780"> 데모</a>
    ·
    <a href="https://github.com/mommocmoc/SmileFaceSDK/issues">버그 제보</a>
    ·
    <a href="https://github.com/mommocmoc/SmileFaceSDK/issues">추가 기능 & 협업 제안</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#프로젝트-소개">프로젝트 소개(About The Project)</a>
    </li>
    <li>
      <a href="#시작하기">시작하기(Getting Started)</a>
      <ul>
        <li><a href="#Unity-버전-관련-정보">Unity 버전 관련 정보</a></li>
<!--         <li><a href="#installation">설치하기(Installation)</a></li> -->
      </ul>
    </li>
    <li><a href="#사용법">사용법</a></li>
<!--     <li><a href="#roadmap">Roadmap</a></li> -->
    <li><a href="#프로젝트에-기여하기">프로젝트에 기여하기</a></li>
    <li><a href="#license">라이센스(License)</a></li>
    <li><a href="#contact">문의&협업(Contact)</a></li>
    <li><a href="#acknowledgments">감사의 말</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## 프로젝트 소개

<!-- [![Product Name Screen Shot][product-screenshot]](https://indie.onstove.com/ko/games/780) -->

- 본 프로젝트는 10년 이상 게임 창작 생태계 저변 확대를 위해 Smilegate Mebership 프로그램을 비롯하여 다양한 프로그램을 통해 [게임 창작자를 지원](https://futurelab.center/front/business/environment-2)하고 [인디 게임 생태계를 활성화](https://indie.onstove.com/ko/store/recommend)시키고 있는 글로벌 엔터테인먼트 그룹 [스마일게이트](https://smilegate.com/ko/company/about.do)의 사내 창작 지원 프로그램 Creative Challenger's League와 Master's League를 통해 개발되었습니다. 
- 대부분의 게임이 손이라는 신체를 사용해야만 하는 현 상황에서 더 많은 사람들이 즐겁게 게임을 즐길 수 있도록 웹캠과 얼굴과 표정을 사용해 게임을 컨트롤하고 즐길 수 있도록 SmileFace SDK를 개발하여 오픈소스 프로젝트로 공개합니다. 

### 개발 배경
첫 시작은 2017년, 인터렉티브 디자인 수업에서 처음으로 얼굴 인식을 활용해 뭔가를 만들어보고 싶었습니다. 처음에는 얼굴로 연주하는 악기를 만드려고 했는데, 생각보다 재미없어서... 
당시 유행하던 소위 항아리 게임(원제- Getting Over It)처럼 유저가 고통을 극복하고 이겨내는 보람(?)을 느낄 수 있는 얼굴 컨트롤을 활용한 간단한 게임을 제작했습니다. 이걸 꼭 정식 출시해봐야지! 하고 3년의 세월이 어찌저찌 흘러... (**두둥**) 스마일게이트에 입사하게 되었습니다!

#### 사내 창작 지원 프로그램 Creative Challenger's League, Master's League를 만나다.
스마일게이트 입사 0년차.. CCL이란 프로그램을 사내 공지에서 보게됩니다. 당시 팀장님도 희망스튜디오 소속 직원이 참여한 케이스가 없어 꼭 참여해보면 좋겠다고 하셔서, 2017년 정식 출시를 꿈꿨던 얼굴 컨트롤을 활용한 게임을 다시 새롭게 개발해보고자 도전하게되었습니다. 3개월의 창작 지원을 통해 프로토타입을 만들 수 있었고, 그 프로토타입을 바탕으로 CCL의 다음 단계인 ML에 도전하게되었습니다.

#### 웃음이 적어지는 세상에, 더 많이 웃으며 행복해지길 바라는 마음으로 얼굴로 즐기는 게임을 개발하려고 했습니다.
게임의 본질은 즐거움이라고 생각합니다. 함께 혹은 혼자 웃으며 즐길 수 있는 게임을 만들고자 고민하며 개발을 했습니다.
그러나 현업과 게임 개발을 함께하는 것이 현실적으로 쉽지 않았습니다. 레벨 디자인부터 아트, 사운드, 프로그래밍까지 전부 다 해야하는 상황에서, 전문적으로 게임을 경험한 적이 없어 부족함을 많이 느꼈습니다. 그래서 사내 멘토(여승환 이사님)의 조언에 따라 창작자들이 얼굴 컨트롤을 게임에 쉽게 활용할 수 있는 SDK를 오픈소스로 공개해서 배포하는 방향으로 프로젝트의 방향을 수정했습니다.
내 게임만 개발하는 것보다 오히려 다른 창작자분들이 함께 사용 할 수 있는 기본 툴을 만드는 생각에 신이 났습니다.

#### 그래서 SmileFaceSDK로 얼굴과 표정이라는 새로운 대안적 컨트롤러의 가능성을 함께 살펴보고싶은 게임 창작자분들과 함께하고 싶습니다.
**우리의 얼굴을 활용해 게임을 즐길 수 있다면, 보다 더 많은 사람들이 게임을 즐길 수 있게 될 것이라고 생각합니다.**

저는 여전히 웃상.전설이란 제목으로 SmileFaceSDK를 활용한 게임을 개발하고 있습니다. 
얼굴 인식을 활용한 게임의 한 사례로 게임 창작자분들이 얼굴 인식으로 어떤 게임을 만들 수 있을 지 영감을 얻으실 수 있도록 간단한 데모 게임도 공개해두었습니다.
게임 개발에 공통으로 사용하는 입력 값을 얼굴에 매핑해 활용하거나 얼굴 표정이나 방향 등의 값을 활용해 뭔가 새로운 아이디어로 게임을 창작해보고 싶은 게임 창작자분들과 함께 하고 싶습니다.

<p align="right">(<a href="#top">back to top</a>)</p>

## SDK 활용 프로젝트(더 많은 프로젝트가 업데이트 되길 바라며...)
- [얼굴로 총알 피하기 데모](https://indie.onstove.com/ko/games/780)
- [대학생 때, 얼굴로 연주하는 악기 만드려던 시도..ㅎㅎ](https://youtu.be/GARD7_ik7yE)
- [웃상.전설 CCL 프로토타입 영상](https://youtu.be/YoOU4lEbE3k)
- [웃상.전설 ML 버전 데모 영상](https://youtu.be/WTc1ntseUgc)

<!-- GETTING STARTED -->
## 시작하기

Unity Package Manager에서 본 Git URL을 통해 설치하거나, Unitypackage 파일을 [다운로드][unity-package-file-link] 하세요.

### Unity 버전 관련 정보

본 프로젝트는 Unity 2020.3.28f1 버전에서 제작 및 테스트 되었습니다. 해당 버전 이상의 유니티 버전을 사용해주세요. 
<!-- * npm
  ```sh
  npm install npm@latest -g
  ``` -->

<!-- ### 설치하기

1. Get a free API Key at [https://example.com](https://example.com)
2. Clone the repo
   ```sh
   git clone https://github.com/github_username/repo_name.git
   ```
3. Install NPM packages
   ```sh
   npm install
   ```
4. Enter your API in `config.js`
   ```js
   const API_KEY = 'ENTER YOUR API';
   ```
 -->
<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## 사용법
- 사용 전에 `Smaple Scenes` 폴더에 샘플 씬들을 살펴보세요.
- 얼굴 표정(화남, 기쁨, 놀람 등)과 얼굴의 방향을 활용해 기본적인 게임 조작이 가능합니다. 

1. Canvas를 하나 만들어 `Prefabs` 폴더에 `SmileFaceAnalyzer` 프리팹을 넣어주세요.
2. `Scripts` 폴더에 `FaceControllerExample` 스크립트를 참고해 `FaceControllerTemplate` 스크립트를 복제해 게임에 필요한 컨트롤러 코드를 작성하세요.
3. 제어하고 싶은 오브젝트를 추가해 작성한 컨트롤러 스크립트를 넣어주세요.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
<!-- ## Roadmap

- [ ] Feature 1
- [ ] Feature 2
- [ ] Feature 3
    - [ ] Nested Feature

See the [open issues](https://github.com/github_username/repo_name/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>
 -->


<!-- CONTRIBUTING -->
## 프로젝트에 기여하기

SmileFace SDK는 더 많은 사람들이 함께 게임을 즐길 수 있는 다양한 제안과 기능 추가에 대한 의견을 환영합니다. 

개선된 스크립트 코드에 대한 기여는 아래와 같은 방법으로 Pull 요청을 부탁드립니다.
프로젝트에 Star도 꼭 부탁드려요!

<!-- Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.
If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!
 -->
1. 프로젝트 Fork (Fork the Project)
2. Feature 브랜치 만들기(Create your Feature Branch) (`git checkout -b feature/AmazingFeature`)
3. Commit하기(Commit your Changes) (`git commit -m 'Add some AmazingFeature'`)
4. 브랜치에 Push(Push to the Branch) (`git push origin feature/AmazingFeature`)
5. Pull 요청(Open a Pull Request)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## 라이센스

Distributed under the BSD 3 Caluse License.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## 문의&협업
<!-- [@twitter_handle](https://twitter.com/twitter_handle)  -->
소재환 - cowcowwow@kakao.com
스마일게이트 000 - 

Project Link: [https://github.com/mommocmoc/SmileFaceSDK](https://github.com/mommocmoc/SmileFaceSDK)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## TODO
- [ ] 상세 가이드 문서 제작 [가이드](https://example.com)
- [ ] 예제 추가
- [ ] 이슈 관리
- [ ] Social preview 이미지 제작

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/mommocmoc/SmileFaceSDK.svg?style=for-the-badge
[contributors-url]: https://github.com/mommocmoc/SmileFaceSDK/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/mommocmoc/SmileFaceSDK.svg?style=for-the-badge
[forks-url]: https://github.com/mommocmoc/SmileFaceSDK/network/members
[stars-shield]: https://img.shields.io/github/stars/mommocmoc/SmileFaceSDK.svg?style=for-the-badge
[stars-url]: https://github.com/mommocmoc/SmileFaceSDK/stargazers
[issues-shield]: https://img.shields.io/github/issues/mommocmoc/SmileFaceSDK.svg?style=for-the-badge
[issues-url]: https://github.com/mommocmoc/SmileFaceSDK/issues
<!-- [license-shield]: https://img.shields.io/github/license/mommocmoc/SmileFaceSDK.svg?style=for-the-badge -->
[license-shield]: https://img.shields.io/badge/License-BSD%203--Clause-blue.svg
<!-- [license-url]: https://github.com/mommocmoc/SmileFaceSDK/blob/master/LICENSE.txt -->
[license-url]: https://opensource.org/licenses/BSD-3-Clause
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: https://d2x8kymwjom7h7.cloudfront.net/live/application_no/119001/application_no/119001/images/1_1648402957564.png
[unity-package-file-link] : https://drive.google.com/drive/folders/1zku6zgjMW8wBUlHmlRYiQTBM8ZkGyQYS?usp=sharing
