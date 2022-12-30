import { useLayoutEffect } from 'react';
import './App.css';
import Main from './pages/Main';

function App() {
  useLayoutEffect(() => { document.body.style.backgroundColor = 'white' }, []) 
  return (
    <div className="App">
      <Main/>
    </div>
  );
}

export default App;
