# ATE for iOS

Модуль предназначен для интеграции включения параметра <b> Advertiser Tracking-Enabled (ATE) </b> через нативный попап <b> iOS </b> для <b> Facebook SDK </b> в проектах.

# Dependencies

Добавьте следующие зависимости в <b> manifest.json </b>:

```json

"com.littlebitgames.nativepopups": "https://github.com/LittleBitOrganization/native-popups.git#1.0.0",
"com.google.external-dependency-manager" : "https://github.com/LittleBitOrganization/evolution-engine-google-version-handler.git#1.2.175",
"com.littlebitgames.coremodule": "https://github.com/LittleBitOrganization/evolution-engine-core.git#1.4.1",
"com.littlebitgames.datastoragemodule": "git@bitbucket.org:little-bit-games/evolution-engine-storage.git",
"com.littlebitgames.savemodule": "git@bitbucket.org:little-bit-games/evolution-engine-save.git",

```

# Quick Start

1. Через Zenject добавьте в <b> ProjectContext </b> или <b> SceneContext </b> инсталлеры из модуля:

![Alt text](https://github.com/LittleBitOrganization/documentation-resources/blob/master/ate-ios/documentation-images/installers.png)

# Data Storage

Создаётся Data с ключом "ATE" для сохранения результата параметра, который выберет пользователь :
<b> Allow </b> - true, <b> Ask App Not to Track </b> - false.

# ATE Popup Service

Включает нативный попав при запуске каждый раз, если значение параметра <b> ATE = false</b>.
При нажатии на кнопки в попапе в <b> Facebook </b> отправляется значение параметра <b> ATE</b>.