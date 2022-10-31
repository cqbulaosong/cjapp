-- auto-generated definition
create schema tiga collate utf8mb4_general_ci;

create table tiga.article
(
    article_id        varchar(21)   not null
        primary key,
    article_title     varchar(50)   not null,
    article_sub_title varchar(50)   null,
    article_author    varchar(50)   not null,
    article_content   varchar(2000) null,
    gmt_create        datetime      not null,
    gmt_modified      datetime      not null,
    is_deleted        tinyint       not null,
    create_user_id    varchar(21)   null,
    modified_user_id  varchar(21)   null,
    constraint article_id_aindex
        unique (article_id)
);

INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('3HqZ5_duHJrkf_1Eb-QoG', '春望', '唐', '杜甫', '国破山河在，城春草木深。
感时花溅泪，恨别鸟惊心。
烽火连三月，家书抵万金。
白头搔更短，浑欲不胜簪。', '2022-07-02 15:25:25', '2022-07-02 15:25:25', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('8_eWa5a5N8onBPzATHYRa', '茅屋为秋风所破歌', '唐', '杜甫', '八月秋高风怒号，卷我屋上三重茅。
茅飞渡江洒江郊，高者挂罥长林梢，下者飘转沉塘坳。
南村群童欺我老无力，忍能对面为盗贼，公然抱茅入竹去。
唇焦口燥呼不得，归来倚杖自叹息。
俄顷风定云墨色，秋天漠漠向昏黑。
布衾多年冷似铁，娇儿恶卧踏里裂。
床头屋漏无干处，雨脚如麻未断绝。
自经丧乱少睡眠，长夜沾湿何由彻？
安得广厦千万间，大庇天下寒士俱欢颜，风雨不动安如山！
呜呼！何时眼前突兀见此屋，吾庐独破受冻死亦足！', '2022-07-02 15:25:25', '2022-07-02 15:55:58', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('Cq-f5cdP9tbEJRYCi3G8E', '一剪梅·红藕香残玉簟秋', '宋', '李清照', '红藕香残玉簟秋。轻解罗裳，独上兰舟。云中谁寄锦书来，雁字回时，月满西楼。
花自飘零水自流。一种相思，两处闲愁。此情无计可消除，才下眉头，却上心头。', '2022-07-02 15:09:14', '2022-07-02 15:09:14', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('GO0Mw5d7S85oDuMSc3oGi', '渔家傲', '宋', '李清照', '天接云涛连晓雾，星河欲转千帆舞。仿佛梦魂归帝所，闻天语，殷勤问我归何处。
我报路长嗟日暮，学诗谩有惊人句。九万里风鹏正举。风休住，蓬舟吹取三山去！', '2022-07-02 15:09:14', '2022-07-02 15:09:14', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('GOZ250iyqN2wZTaZ83F7a', '武陵春·春晚', '宋', '李清照', '风住尘香花已尽，日晚倦梳头。物是人非事事休，欲语泪先流。
闻说双溪春尚好，也拟泛轻舟。只恐双溪舴艋舟，载不动许多愁。', '2022-07-02 15:09:14', '2022-07-02 15:09:14', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('mWNhxV1sSsww8HHYuGJYe', '绝句', '唐', '杜甫', '两个黄鹂鸣翠柳，一行白鹭上青天。
窗含西岭千秋雪，门泊东吴万里船。', '2022-07-02 15:25:25', '2022-07-02 15:25:25', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('R7doDZg2VFKXMjeH_rJRC', '望岳', '唐', '杜甫', '岱宗夫如何，齐鲁青未了。
造化钟神秀，阴阳割昏晓。
荡胸生曾云，决眦入归鸟。
会当凌绝顶，一览众山小。', '2022-07-02 15:25:25', '2022-07-02 15:25:25', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('reLDJAPEJxDO_cGCKHYK8', '滕王阁', '唐', '王勃', '滕王高阁临江渚，佩玉鸣鸾罢歌舞。
画栋朝飞南浦云，珠帘暮卷西山雨。
闲云潭影日悠悠，物换星移几度秋。
阁中帝子今何在？槛外长江空自流。', '2022-06-11 15:16:02', '2022-06-11 15:16:02', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('RMBZkDu3JZXCdMFiRyo7f', '春江花月夜', '唐', '张若虚', '春江潮水连海平，海上明月共潮生。
滟滟随波千万里，何处春江无月明！
江流宛转绕芳甸，月照花林皆似霰；
空里流霜不觉飞，汀上白沙看不见。
江天一色无纤尘，皎皎空中孤月轮。
江畔何人初见月？江月何年初照人？
人生代代无穷已，江月年年望相似。
不知江月待何人，但见长江送流水。
白云一片去悠悠，青枫浦上不胜愁。
谁家今夜扁舟子？何处相思明月楼？
可怜楼上月裴回，应照离人妆镜台。
玉户帘中卷不去，捣衣砧上拂还来。
此时相望不相闻，愿逐月华流照君。
鸿雁长飞光不度，鱼龙潜跃水成文。
昨夜闲潭梦落花，可怜春半不还家。
江水流春去欲尽，江潭落月复西斜。
斜月沉沉藏海雾，碣石潇湘无限路。
不知乘月几人归，落月摇情满江树。', '2022-07-02 15:02:50', '2022-07-02 15:02:50', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('tG8ZC1lS8JUvrk6oSWl8D', '将进酒', '唐', '李白', '君不见黄河之水天上来，奔流到海不复回。
君不见高堂明镜悲白发，朝如青丝暮成雪。
人生得意须尽欢，莫使金樽空对月。
天生我材必有用，千金散尽还复来。
烹羊宰牛且为乐，会须一饮三百杯。
岑夫子，丹丘生，将进酒，杯莫停。
与君歌一曲，请君为我倾耳听。
钟鼓馔玉不足贵，但愿长醉不愿醒。
古来圣贤皆寂寞，惟有饮者留其名。
陈王昔时宴平乐，斗酒十千恣欢谑。
主人何为言少钱，径须沽取对君酌。
五花马、千金裘，呼儿将出换美酒，与尔同销万古愁。', '2022-06-11 15:18:07', '2022-06-11 15:18:07', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('UtiGbpDbiJJn0020A7AgA', '登高', '唐', '杜甫', '风急天高猿啸哀，渚清沙白鸟飞回。
无边落木萧萧下，不尽长江滚滚来。
万里悲秋常作客，百年多病独登台。
艰难苦恨繁霜鬓，潦倒新停浊酒杯。', '2022-07-02 15:25:25', '2022-07-02 15:25:25', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('w_1XF9E8-3X7s54SLmHHX', '蜀道难', '唐', '李白', '噫吁嚱，危乎高哉！
蜀道之难，难于上青天！
蚕丛及鱼凫，开国何茫然！
尔来四万八千岁，不与秦塞通人烟。
西当太白有鸟道，可以横绝峨眉巅。
地崩山摧壮士死，然后天梯石栈相钩连。
上有六龙回日之高标，下有冲波逆折之回川。
黄鹤之飞尚不得过，猿猱欲度愁攀援。
青泥何盘盘，百步九折萦岩峦。
扪参历井仰胁息，以手抚膺坐长叹。
问君西游何时还？畏途巉岩不可攀。
但见悲鸟号古木，雄飞雌从绕林间。
又闻子规啼夜月，愁空山。
蜀道之难，难于上青天，使人听此凋朱颜！
连峰去天不盈尺，枯松倒挂倚绝壁。
飞湍瀑流争喧豗，砯崖转石万壑雷。
其险也如此，嗟尔远道之人胡为乎来哉！
剑阁峥嵘而崔嵬，一夫当关，万夫莫开。
所守或匪亲，化为狼与豺。
朝避猛虎，夕避长蛇，磨牙吮血，杀人如麻。
锦城虽云乐，不如早还家。
蜀道之难，难于上青天，侧身西望长咨嗟！', '2022-06-11 15:20:52', '2022-06-11 15:20:52', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('z6ZZYIaS1dQTMqmlbjUIH', '醉花阴·薄雾浓云愁永昼', '宋', '李清照', '薄雾浓云愁永昼，瑞脑销金兽。佳节又重阳，玉枕纱厨，半夜凉初透。
东篱把酒黄昏后，有暗香盈袖。莫道不销魂，帘卷西风，人比黄花瘦。', '2022-07-02 15:09:14', '2022-07-02 15:09:14', 0, 'admin', 'admin');
INSERT INTO tiga.article (article_id, article_title, article_sub_title, article_author, article_content, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('_lfRahn4HPSkLbFZY6tq2', '夏日绝句', '宋', '李清照', '生当作人杰，死亦为鬼雄。
至今思项羽，不肯过江东。', '2022-07-02 15:09:14', '2022-07-02 15:09:14', 0, 'admin', 'admin');

-- auto-generated definition
create table systemuser
(
    system_userid    varchar(21) not null
        primary key,
    full_name        varchar(50) not null,
    email            varchar(30) not null,
    phone            varchar(11) not null,
    password         varchar(32) not null,
    gmt_create       datetime    not null,
    gmt_modified     datetime    not null,
    is_deleted       tinyint     not null,
    create_user_id   varchar(21) null,
    modified_user_id varchar(21) null,
    constraint system_userid_aindex
        unique (system_userid),
    constraint systemuser_email_uindex
        unique (email),
    constraint systemuser_phone_uindex
        unique (phone)
);

INSERT INTO tiga.systemuser (system_userid, full_name, email, phone, password, gmt_create, gmt_modified, is_deleted, create_user_id, modified_user_id) VALUES ('8_eWa5a5N8onBPzATHYRa', '系统管理员', '1285461861@qq.com', '18156198235', 'e10adc3949ba59abbe56e057f20f883e', '2022-08-06 22:24:12', '2022-08-06 22:24:14', 0, 'admin', 'admin');