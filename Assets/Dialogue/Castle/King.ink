VAR princess_name = "月子"
VAR kingdom_name = "希爾王國"
VAR hero_name = "瑪寇投"

===go_castle===
勇者歡迎你的來到 #speaker: king
最近王國附近的魔物有增多的現象
往來王國的商隊被襲擊的頻率也增加了不少
而就在昨天我的愛女{princess_name}只是與商隊前往鄰國洽公
就被不明魔物襲擊
給綁架走了
我十分的著急，要求四傑立馬進行調查
根據四傑所秉告的內容
似乎是魔王又再次重新崛起了
但魔王依照傳說只有勇者有辦法討伐
為了愛女也為了王國的和平
我在此以{kingdom_name}之名，賜予你討伐魔王的使命
->question

===question===
你應該會同意吧 #speaker: king
    * [同意] 
        （這情況看來是不能不答應） #speaker: hero #mission: defeat_boss
        不愧是勇者我就知道你會答應 #speaker: king
        這是傳說的勇者之劍，我就將其借給你直到討伐完魔王
        （蛤，我要幫你討伐魔王你卻只把勇者之劍借我而已）#speaker: hero
        才怪 #speaker: king
        （蛤！）#speaker: hero
        等你能證明你有辦法打倒魔王，我再把劍借你 #speaker: king
        不然你如果把{kingdom_name}流傳下來的寶劍賣掉了怎麼辦
        那可以是用你一百條的性命都換不了的珍貴國寶
        （等下等下，我是勇者吧）#speaker: hero
        （我是被拜託地吧）
        （我連那把破劍都不如，那你幹嘛不自己上場）
        冒昧請問殿下
        那要完成什麼樣的任務才可以得到殿下的肯定，來向殿下借取勇者之劍 
        我怎麼會知道，你是勇者你總該知道完成什麼任務，我才願意借你吧 #speaker: king
        （這國王是怎樣，拜託人還用這種態度）#speaker: hero
        （要不要直接開扁）
        （不行不行我在想什麼，打國王可是會被砍頭的）
        但當然我也不會什麼都不給你 #speaker: king
        （看來還是有給東西嗎，雖然不是勇者之劍，但應該也不差吧）#speaker: hero
        來這是王宮名師做出來的 "希爾木棍"#speaker: king
        你收下吧
        （木棍？？？你要我拿這個東西去幫你完成使命？？？）#speaker: hero
        （開玩笑地吧）
        勇者等你的好消息 #speaker: king
        {hero_name}獲得了 "希爾木棍" #namepanel: off
        ->DONE
    * [不同意]
        -> question
->END

===mission_proceed_1===
我等你把魔王討伐的好消息 #speaker: king
希望愛女可以平安
->END