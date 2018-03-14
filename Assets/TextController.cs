using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public Text text;
	private enum States {cell, combat_0, cell_0, BadEnd_0, GoodEnd_0, GoodEnd_1, BadEnd_1, Freedom};
	private States myState;
	// Use this for initialization
	void Start () {
		myState=States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if(myState == States.cell){
			Cell ();
		}else if(myState == States.combat_0){
			Combat_0();
		}else if(myState == States.GoodEnd_0){
			GoodEnd_0();
		}else if(myState == States.BadEnd_0){
			BadEnd_0();
		}else if(myState == States.cell_0){
			Cell_0();
		}else if(myState == States.GoodEnd_1){
			GoodEnd_1();
		}else if(myState == States.BadEnd_1){
			BadEnd_1();
		}else if(myState == States.Freedom){
			Freedom();
		}		
	}
	
	#region state methods
	void Cell(){
		text.text="你从头痛欲裂的疼痛中醒来,发现自己身处一个黑漆漆的地窖."+
				"突然,你的耳边响起一个声音.\"威廉,你醒了,快拿起手边的匕首,逃出这个地牢吧\""+
				"你一个激灵,朝四周环顾了一番,果然在你脚边有一把明晃晃的匕首,上面还隐约有些血渍.\n\n"+
				"按下P捡起匕首,按下I无视建议继续睡觉";
		if(Input.GetKeyDown(KeyCode.P)){
			myState=States.combat_0;
		}else if(Input.GetKeyDown(KeyCode.I)){
			myState=States.cell_0;
		}
	}
	
	void Combat_0(){
		text.text="你拿起了匕首,突然发现地牢门口有脚步声,你屏住呼吸,紧握着匕首,仔细听着越来越清晰的脚步朝你而来."+
				"你看到一个全身武装的警卫从你的地牢门口经过,边走还边打着哈欠,你讲手放在地牢的门上,发现根本就没有锁!"+
				"你想了想,脑海里又出现了那个声音.\"威廉,是时候展示真正的技术了!\"\n\n"+
				"按下F正面刚守卫,按下B从背后偷袭守卫";
		if(Input.GetKeyDown(KeyCode.F)){
			myState=States.BadEnd_0;
		}else if(Input.GetKeyDown(KeyCode.B)){
			myState=States.GoodEnd_0;
		}
	}
	
	void GoodEnd_0(){
		text.text="你紧盯着守卫的背,紧了紧手里的匕首,看准了守卫低头的瞬间."+
				"说时迟那时快,你用力将匕首捅了进去.守卫甚至来不及惊叫一声,就一脸惊诧地倒了下去."+
				"你搜了搜守卫的身上,果然有一把厚重的钥匙,你拿出钥匙打开了监狱大门,眼前是你许久未见的自由\n\n"+
				"按下F享受自由享受人生";
		if(Input.GetKeyDown(KeyCode.F)){
			myState=States.Freedom;
		}
	}
	
	void BadEnd_0(){
		text.text="你拿起了匕首,感觉充满了勇气,二话不说提起匕首,大踏步地推开地牢门来到守卫面前."+
				"你双手叉腰,昂着头正准备说什么.守卫突然掏出长枪,对着你的心窝就是一刺."+
				"你顿时眼前一黑,耳边响起守卫的声音\"哇,吓死老子了,还好老子反应快!\"\n\n"+
				"你已经嗝屁了,按下T施展时光倒流回到最初的选择";
		if(Input.GetKeyDown(KeyCode.T)){
			myState=States.cell;
		}
	}
	
	void Cell_0(){
		text.text="你瞅了瞅那匕首,二话不说将其塞到了床底.看着地上的杂草,困意大起,一头栽进去继续呼呼大睡起来."+
				"不知道过了多久,你被门口守卫的声音吵醒.\"起来起来,有人保释你了!\""+
				"你揉了揉眼睛,发现地牢门口站着你爸爸马云,手里拿着一大摞人民币正在朝天上撒,"+
				"周围的守卫头也不抬地跪在地上捡钱.你无奈地耸耸肩.\n\n"+
				"按下B和爸爸打招呼,按下S捡起地上的钞票";
		if(Input.GetKeyDown(KeyCode.B)){
			myState=States.GoodEnd_1;
		}else if(Input.GetKeyDown(KeyCode.S)){
			myState=States.BadEnd_1;
		}
	}
	
	void GoodEnd_1(){
		text.text="\"爸爸,我..\"你看着马爸爸,不知道说什么好"+
				"\"闭嘴,拿着着50亿人民币跟我走.\"马爸爸的声音不容置疑,你拿着爸爸给你的钱跟在他后面出了地牢"+
				"一路上的NPC都朝圣一般地跪在道路两边拜着马爸爸,而爸爸回头对你一笑,说"+
				"\"你接下来自由了,该干嘛干嘛去吧.\"\n\n"+
				"按下F享受自由享受人生";
		if(Input.GetKeyDown(KeyCode.F)){
			myState=States.Freedom;
		}
	}
	
	void BadEnd_1(){
		text.text="说时迟那时快,一个黑影迅速地出现在你身后,电光火石之间,你只觉得腰间一阵剧痛."+
				"你低头一看,大量鲜血正从你的腹部涌出.\"你!\"你一脸惊诧,看着身后两眼放光的NPC大妈."+
				"大妈嘿嘿一笑,抢过你手里的钞票,朝你的尸体吐了一口口水,又回头发疯一般地抢钱去了.\n\n"+
				"赶紧按下T时间倒流吧,马爸爸还在等你呢";
		if(Input.GetKeyDown(KeyCode.T)){
			myState=States.cell;
		}
	}
	
	void Freedom(){
		text.text="..............."+
				"..............."+
				"..............."+
				"..............."+
				"盯着看也不会有后续的哦...我推荐你关掉这个破游戏比较好.";
	}
	#endregion
	
}
