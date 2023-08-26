import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

const AllLesson = () => {

    const [lesson, setlessons] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        axios.get("https://localhost:44316/api/lesson/all")
            .then(response => {
                console.log(response.data);
                setlessons(response.data);
            }).catch(err => {
                console.log(err);
            })
    }, []);
    return (
        <div>
            <div class="container mt-5">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">Title</th>
                            <th scope="col">Description</th>
                            <th scope="col">File</th>
                        </tr>
                    </thead>
                    <tbody>
                        {lesson.map(lesson => (
                            <tr key={lesson.Id}>
                                <td>{lesson.Title}</td>
                                <td>{lesson.Description}</td>
                                <td>{lesson.File}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default AllLesson;