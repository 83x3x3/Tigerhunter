using System;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Numerics;
using System.Reflection.Emit;
// Can i write?
namespace TigerHunter
{
	public class Strings
	{
		public static string anounceEnter = "시작하려면 엔터를 입력해주세요.";
		public static void AnounceEnter()
		{
			Console.WriteLine($"{anounceEnter}");
		}

		public static string anounceIntroductionCharacter = "\n 캐릭터를 선택해주세요 .\n";
		public static string introductionCharacterDolshoi = "     돌쇠	[1]	\"아씨는 제가 구해오겠구만유!\"";
		public static string introductionCharacterMadangshoi = "     마당쇠	[2]	\"우리 아부지가 왕년에 범사냥꾼이었지 않것수?\"";
		public static string introductionCharacterHyangdan = "     향단이	[3]	\"어쩜 좋아... 아가씨는 내가 구해야해...!\"";
		public static string introductionCharacterSmith = "     스미스	[4]	\"Listen, Listen, I can't listen.\"\n";

		public static void AnounceChoice()
        {
            Console.WriteLine($"{anounceIntroductionCharacter}");
            Console.WriteLine($"{introductionCharacterDolshoi}");
			Console.WriteLine($"{introductionCharacterMadangshoi}");
			Console.WriteLine($"{introductionCharacterHyangdan}");
			Console.WriteLine($"{introductionCharacterSmith}");
		} //캐릭터 설렉 어나운스

        public static string selectDolshoi = "\n당신의 캐릭터는 돌쇠 입니다.\n";
        public static string selectMadangshoi = "\n당신의 캐릭터는 마당쇠 입니다.\n";
        public static string selectHyangdan = "\n당신의 캐릭터는 향단 입니다.\n";
        public static string selectSmith = "\n당신의 캐릭터는 스미스 입니다.\n";
        public static void AnounceSelect(int i)
		{
			switch (i)
			{
                case 1:
                    Console.WriteLine($"{selectDolshoi}");
                    break;
                case 2:
                    Console.WriteLine($"{selectMadangshoi}");
                    break;
                case 3:
                    Console.WriteLine($"{selectHyangdan}");
                    break;
                case 4:
                    Console.WriteLine($"{selectSmith}");
                    break;
                default:
					break;
			} //당신의 캐릭터는
        }

		public static void AnounceGo(int sum)
		{
			if (sum == 0)
				Console.WriteLine($"4 칸 이동합니다.\n");
			else
				Console.WriteLine($"{sum} 칸 이동합니다.\n");
		}


	}

    public class Human
	{
		public int Hp;
		public int Mp;
		public int exp;
		public int level;
	} // 캐릭터 부모클래스
	public class Player : Human
	{
		public static int MyCharacter;
		public Player()
		{
			exp = 0;
			level = 1;			
		}

		public Player CreatDolshoi()
		{
			Hp = 10;
			Mp = 3;
			MyCharacter = 1;
			return this;
		}
		public Player CreatMadangshoi()
		{
			Hp = 8;
			Mp = 8;
			MyCharacter = 2;
			return this;
		}
		public Player CreatHyangdan()
		{
			Hp = 5;
			Mp = 10;
			MyCharacter = 3;
			return this;
		}
		public Player CreatSmith()
		{
			Hp = 20;
			Mp = 1;
			MyCharacter = 4;
			return this;
		}

		public Player(int i) : this()
		{
			switch (i)
			{
				case 1:
					Strings.AnounceSelect(i);
					CreatDolshoi();
					break;
				case 2:
					Strings.AnounceSelect(i);
					CreatMadangshoi();
					break;
				case 3:
                    Strings.AnounceSelect(i);
					CreatHyangdan();
					break;
				case 4:
                    Strings.AnounceSelect(i);
					CreatSmith();
					break;
				default:
					break;
			}

		}
	} // 캐릭터 자식클래스

	static class Program
	{
		public static class Map
		{
			public static int locate = 0;
			public const int TigerD = 15;
			public static int round = 0;

		} // 현재 맵 위치 및 locate별 이벤트 코드

		public static class CharacterClass 
		{
			public static int MyCharacter = 0;
		} // 캐릭터 식별 코드

		public static int TigerDen()
		{
			if (Map.locate == Map.TigerD)
			{
				Console.WriteLine("어흥! 호랑이 굴이다");
				return 1;
			}
			return 0;
		} // 엔딩

		static int Choice()
		{
			Strings.AnounceChoice();

			String input = Console.ReadLine();
			switch (input)
			{
				case "1":
					return (int)1;
				case "2":
					return (int)2;
				case "3":
					return (int)3;
				case "4":
					return (int)4;
				default: break;
			}
			return 0;
		} // 캐릭터 선택

		static void Enter()
		{
			while (true)
			{
				Strings.AnounceEnter();
				
				String input = Console.ReadLine();
				if (input == "")
					break;
			}
		} // Enter

		static void AnounceLocate()
		{
			Console.WriteLine(" 윷을 던져주세요 .\n");
			Console.WriteLine(" 윷을 던질 힘을 입력해주세요. [ 1 ~ 10 ]\n\n");
		} // 윷놀이 어나운스

		public struct Yoots
		{
			public int backYoot;
			public int yoot1;
			public int yoot2;
			public int yoot3;
		} // 윷

		public static Yoots RollYoots(int seed)
		{
			Random random = new Random((int)DateTime.Now.Ticks + seed);

			Yoots yoots;
			yoots.backYoot = random.Next(0, 10) >= 5 ? 1 : 0;
			yoots.yoot1 = random.Next(0, 10) >= 5 ? 1 : 0;
			yoots.yoot2 = random.Next(0, 10) >= 5 ? 1 : 0;
			yoots.yoot3 = random.Next(0, 10) >= 5 ? 1 : 0;

			return yoots;
		} // 윷 던지기

		public static int GetValidSeed()
		{
			int seed;
			bool isValidSeed;

			do
			{
				AnounceLocate();
				isValidSeed = int.TryParse(Console.ReadLine(), out seed);

				if (isValidSeed)
				{
					if (seed < 1 || seed > 10)
					{
						Console.WriteLine("잘못된 입력입니다. 1에서 10 사이의 숫자를 입력해주세요.");
							isValidSeed = false;
					}
				}
				else
					Console.WriteLine("잘못된 입력입니다. 1에서 10 사이의 숫자를 입력해주세요.");

			} while (!isValidSeed);

			return seed;
		}

		public static int Rolling(Player player)
		{
			int seed = GetValidSeed();

			Yoots yoots = RollYoots(seed);

			if (CharacterClass.MyCharacter == 3)
			{
				yoots.backYoot = 1;
			}

			int sum = yoots.backYoot + yoots.yoot1 + yoots.yoot2 + yoots.yoot3;

			if (yoots.backYoot == 1 && yoots.yoot1 == 0 && yoots.yoot2 == 0 && yoots.yoot3 == 0)
			{
				if (CharacterClass.MyCharacter == 3)
				{
					Console.WriteLine("향단이의 백윷은 항상 뒤집혀 있습니다.");
				}
				Console.WriteLine("    백도..??\n\n    뒤로 한칸 이동합니다.");
				return -1;
			}
			else
			{
				switch (sum)
				{
					case 0:
						Console.WriteLine("\n    윷!\n");
						Strings.AnounceGo(sum);
						return 4;
					case 1:
						Console.WriteLine("\n    도\n");
						Strings.AnounceGo(sum);
						return 1;
					case 2:
						Console.WriteLine("\n    개!\n");
						Strings.AnounceGo(sum);
						return 2;
					case 3:
						Console.WriteLine("\n    걸!\n");
						Strings.AnounceGo(sum);
						return 3;
					case 4:
						Console.WriteLine("\n    모...!!\n");
						Strings.AnounceGo(sum);
						return 5;
					default:
						return 0;
				}
			}
		} // 윷 판정
			static void Main(string[] args)
			{
				Enter();
				Player player = new Player(CharacterClass.MyCharacter = Choice());
				Console.WriteLine($"레벨 : {player.level}\n체력 : {player.Hp}\n정신력 : {player.Mp}");

				while (Map.locate <= Map.TigerD)
				{
				// 매 턴마다 Map.locate를 지역명으로 변환시켜주기. (switch)
					Map.locate += Rolling(player);
					Console.WriteLine($"현재 위치는 {Map.locate}/15 입니다");
					if (TigerDen() == 1)
						break;
				} // 윷놀이 페이즈 != 배틀페이즈

			Console.WriteLine("호랑이를 무찔렀다!");
			}
		}
	}
