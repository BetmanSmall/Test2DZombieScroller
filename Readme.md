Распределил все файлы по папкам.
Скрипты распределены логически по своим папкам.
Assets/Scripts/Enemies - Скрипты относящиеся к противникам.
Assets/Scripts/Player - Скрипты относящиеся к игроку.
Assets/Scripts/Player/Weapons - Скрипты относящиеся к игроку и его оружию.
Assets/Scripts/Ui - Скрипты относящиеся к пользовательскому интерфейсу.
Assets/Scripts/Enemies/EnemyMover.cs - Скрипт отвечающий за передвижения противника.
Assets/Scripts/Enemies/EnemySpawner.cs - Скрипт реализует спавн противников, используется Pooling объектов.
Assets/Scripts/Enemies/ZombieEnemy.cs - Скрипт хранит ХП зомби и после смерти спавнит поднимаемые снаряды для игрока.
Assets/Scripts/Player/Weapomns/Bullets/PlayerBullet.cs - Сущность летящая пуля игрокаюю. 
Assets/Scripts/Player/Weapomns/PickupbleAmmo.cs - Сущность поднимаемые снаряды для игрока.
Assets/Scripts/Player/Weapomns/PlayerBulletSpawner.cs - Спавнер снарядов из дула игрока, используется Polling Objects.
Assets/Scripts/Player/Weapomns/PlayerShooter.cs - Стрельба и проигрывание анимации.
Assets/Scripts/Player/Player.cs - Сущность игрок.
Assets/Scripts/Player/PlayerAmmo.cs - Скрипт для хранения и обработки количества пуль у игрока..
Assets/Scripts/Player/PlayerInput.cs - Обработка ввода от игрока (Old Input)
Assets/Scripts/Player/PlayerMover.cs - Передвижения главное героя.
Assets/Scripts/Ui/AmmoPanel.cs - Отображение количество пуль у игрока.
Assets/Scripts/Ui/GameOverPanel.cs - Скрипт для включения Экрана о проиграше, перезапуск и выход.
Assets/Scripts/AudioManager.cs - Скрипт для управления аудио.