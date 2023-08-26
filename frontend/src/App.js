import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import AddLesson from './Pages/AddLesson';
import AllLesson from './Pages/AllLesson';

function App() {
  return (
    <Router>
      <Routes>
        <Route exact path='/' element={<AddLesson />} />
        <Route exact path='/allLesson' element={<AllLesson />} />
      </Routes>
    </Router>
  );
}

export default App;
