# KometaTicTacToe

<h2>Installers</h2>
<h3>Project Context</h3>

В Project Context находится SaveLoadInstaller для биндинга Save Load системы.

<h3>Scene Context</h3>

В Scene Context находится инсталлеры для фабрики UI, фабрики игрока, конфигов и игроков для их биндинга.

<h2>Запуск игрового процесса</h2>

Запуск игрового процесса происходит в классе GameRoot. GameRoot является стартовой точкой проекта, который создаёт через фабрику UI, активных игроков и стартует игровой уровень.

<h2>Игровой процесс</h2>

<b>Стартовое игровое поле</b> </br>
![image](https://user-images.githubusercontent.com/69348449/221376054-d5e9e72d-197e-4298-9a1b-9e196066d33a.png)</br>

<b>Скриншот игрового процесса</b> </br>
![image](https://user-images.githubusercontent.com/69348449/221376065-48525331-efc6-4bf8-9954-97ca49f92398.png)</br>

На игровом уровне создаются игроки, количество которых определено в конфиге GameConfig. У класса игрока Player есть поле ID, которое нужно для того, чтобы указывать игровому полю какой игрок какую отметку поставил.

Созданные экземпляры класса Player передаются в класс Level. В классе Level реализованы методы, которые управляют игровым процессом на уровне, такие как: победа, ничья, переход хода определенному игроку и рестарт уровня.

При помощи фабрики UI создаётся Canvas, класс Board и экземпляры класса Mark.
Класс Mark - это игровая ячейка, которая представляет из себя кнопку, которая при нажатии меняет свой спрайт в зависимости от того, какой ID присвоил ей игрок. Информацию о нужном спрайте берет из конфига MarksConfig из словаря с ключом в виде ID и значением в виде ссылки на необходимый спрайт.

Класс Board хранит информацию о каждой игровой ячейке. Реагирует на нажатие по игровой ячейке, сохраняя ID ячейки в файл сохранения и обращаясь к классу ResultGameCondition, в котором проверяется исход игры.

При нажатии на кнопку "Restart" сцена перезагружается. Сохранение игры очищается.

<h2>Сохранение и загрузка</h2>

В игре сохраняется очередь игрока на ход и состояние игрового поля.

В конфиге SaveLoadConfig определяется:
<ul>
<li>название файла;</li>
<li>тип файла, в котором необходимо делать сохранение;</li>
<li>тип шифрования файла;</li>
<li>словарь с ключом в виде типа сохранения и значением в виде строкового значения расширения файла.</li>
</ul>


![image](https://user-images.githubusercontent.com/69348449/221377759-8ec2b153-3ced-48e7-8ba8-2fcd3eb69e0c.png)

Сохранение происходит во время перезапуска плей мода в редакторе, либо паузы игры на девайсе.
Загрузка происходит на старте игры, если файл сохранения найден.

Класс LocalSaveLoad хранит в себе структуру SaveLoadData, а также функционал загрузки игры на старте, либо загрузки дефолтных параметров игры, если файл сохранения не создан.

Во время сохранения класс SaveLoadSystem берет у конфига SaveLoadSystemConfig название файла, тип сохранения, тип шифрования и ссылку на структуру SaveLoadData. И записывает результат в файл (если выбран тип записи в json, реализован в игре только он) шифруя данные (реализовано бинарное шифрование), если выбран какой-нибудь тип шифрования.

Во время загрузки класс SaveLoadSystem дешифрует данные файла и записывает результат в структуру SaveLoadData. Если файл сохранения не найден, то создаёт дефолтную реализацию SaveLoadData.
