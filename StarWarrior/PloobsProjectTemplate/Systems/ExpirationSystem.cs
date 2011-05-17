using System;
using Artemis;
using StarWarrior.Components;
namespace StarWarrior
{
	public class ExpirationSystem : EntityProcessingSystem {

		private ComponentMapper expiresMapper;
	
		public ExpirationSystem() : base(typeof(Expires)) {
		}
	
		public override void Initialize() {
			expiresMapper = new ComponentMapper(typeof(Expires), world.GetEntityManager());
		}
	
		public override void Process(Entity e) {
			Expires expires = expiresMapper.Get<Expires>(e);
			expires.ReduceLifeTime(world.GetDelta());
	
			if (expires.IsExpired()) {
				world.DeleteEntity(e);
			}
	
		}
	}
}

