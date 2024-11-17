VAR princess_name = "月子"
VAR kingdom_name = "希爾王國"
VAR hero_name = "瑪寇投"

===go_castle===
歡迎你的來到 #speaker: king
想必你就是那位赫赫有名的勇者的後代吧
最近王國附近的魔物有增多的現象
往來王國的商隊被襲擊的頻率也增加了不少
而就在昨天我的愛女{princess_name}與商隊前往鄰國洽公
就被一群不明魔物襲擊
直到現在仍下落不明
我十分的著急，要求四傑立馬進行調查
根據四傑所秉告的內容
這些魔物似乎都是來自魔王的麾下 
並且魔王有著重振旗鼓的打算
我的愛女也是因此而被擄走當作人質的
但根據古老的傳說，只有勇者能夠討伐魔王
為了愛女也為了我國的和平
我在此以{kingdom_name}之名，賜予你討伐魔王的使命
->question

===question===
你應該會同意吧 #speaker: king
    * [同意] 
        （這情況看來是不能不答應） #speaker: hero #mission: defeat_boss #portrait-panel:on #speaker-portrait:hero_cape_sweating
        真不愧是勇者我就知道你會答應 #speaker: king #portrait-panel:off
        這是傳說的勇者之劍，我就將其「借」給你...
        ...#speaker: hero #portrait-panel:on #speaker-portrait:hero_cape_sweating
        （蛤，我要幫你討伐魔王你卻只把勇者之劍借我而已）#speaker: hero #speaker-portrait:hero_cape_upset
        才怪！ #speaker: king #portrait-panel:off
        （蛤！）#speaker:hero #portrait-panel:on #speaker-portrait:hero_cape_upset 
        等你能證明你有辦法打倒魔王，我再把劍借你 #speaker: king #portrait-panel:off
        不然你如果把{kingdom_name}流傳下來的寶劍賣掉了怎麼辦
        那可以是用你一百條的性命都換不了的珍貴國寶
        （等下等下，我是勇者吧）#speaker: hero #portrait-panel:on #speaker-portrait:hero_cape_upset
        （我是被拜託的那方吧）
        （我連那把破劍都不如，那你幹嘛不自己上場）
        冒昧請問殿下 #speaker-portrait:hero_cape_fake_smile
        那要完成什麼樣的任務才可以得到殿下的肯定
        來向您借取這把勇者之劍呢？
        我怎麼會知道 #speaker: king #portrait-panel:off
        你是勇者你總該知道完成什麼任務才能獲得我的賞識吧 
        （這國王是怎樣，拜託人還用這種態度）#speaker: hero #portrait-panel:on #speaker-portrait:hero_cape_upset
        （跟前面給人的感覺完全不一樣）
        （是等我上鉤了才露出真面目嗎）
        （要不要直接開扁）#speaker-portrait:hero_cape_mad 
        （不行不行我在想什麼，打國王可是會被砍頭的）#speaker-portrait:hero_cape_calm_down
        這樣吧，我看你就先前往隔壁的法雅王國吧 #speaker: king #portrait-panel:off
        那邊最近也頻頻傳出許多魔物襲擊事件
        你就先去試著解決他們吧
        只要穿過希爾王國西邊的那片森林就會到了
        當然我也不會讓你手無寸鐵的踏上旅程  
        （看來還是有給東西的嘛）#speaker: hero #portrait-panel:on #speaker-portrait:hero_cape_confident 
        （雖然不是勇者之劍，但應該也不差吧）
        來，這是由王宮內的名師所打造出來的… #speaker: king #portrait-panel:off
        「希爾木棍」
        (．．．？) #portrait-panel:on #speaker-portrait:hero_cape_no_eyes 
        你收下吧 #speaker: king #portrait-panel:off
        （木棍？？？你要我拿這個東西去幫你完成使命？？？）#speaker: hero #portrait-panel:on #speaker-portrait:hero_cape_upset
        （開玩笑地吧）
        我期待你凱旋歸來的好消息  #speaker: king #portrait-panel:off
        {hero_name}獲得了「希爾木棍」 #namepanel: off 
        ->DONE
    * [不同意]
        -> question
->END

===mission_proceed_1===
我期待你凱旋歸來的好消息  #speaker: king
希望愛女可以平安
->END