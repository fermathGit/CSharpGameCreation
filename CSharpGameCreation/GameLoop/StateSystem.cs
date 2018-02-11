using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop {
    public class StateSystem : IGameObject {
        Dictionary<string, IGameObject> _stateStore = new Dictionary<string, IGameObject>();//等着把string改成枚举，没毛病
        IGameObject _currentState = null;

        public void Render() {
            if ( _currentState == null ) {
                return;
            }
            _currentState.Render();
        }

        public void Update( double elapsedTime ) {
            if ( _currentState == null ) {
                return;
            }
            _currentState.Update( elapsedTime );
        }

        public void AddState( string stateId, IGameObject state ) {
            System.Diagnostics.Debug.Assert( Exists( stateId ) == false );
            _stateStore.Add( stateId, state );
        }

        public void ChangeState( string stateId ) {
            System.Diagnostics.Debug.Assert( Exists( stateId ) );
            _currentState = _stateStore[stateId];
        }

        private bool Exists( string stateId ) {
            return _stateStore.ContainsKey( stateId );
        }
    }
}
