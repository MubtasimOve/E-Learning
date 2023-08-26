import axios from "axios";
import React, { useState } from 'react';
const AddLesson = () => {
    let [Title, setTitle] = useState("");
    let [Description, setDescription] = useState("");
    let [File, setFile] = useState("");

    const addLessonSubmit = (e) => {
        console.log("response.data");
        e.preventDefault();

        axios.post("https://localhost:44316/api/lesson/add", {
            Title,
            Description,
            File
        }).then(response => {
            console.log(response.data);
        }).catch(error => console.log(error))

    }
    return (
        <div>
            <div className='container'>
                <div className="mt-5">
                    <h2 className='text-center'>ADD Lesson</h2>
                </div>
                <div className="container my-5">
                    <form className="shadow-lg p-3 mb-5 bg-body rounded row g-3" action="" method="post">
                        <div className="col-md-7">
                            <label for="validationDefaultEmail" className="Title">Title</label>
                            <div className="input-group">

                                <input type="Title" value={Title} onChange={(e) => setTitle(e.target.value)} className="form-control" id="validationDefaultEmail"
                                    aria-describedby="inputGroupPrepend2" name="Title" placeholder="React" />
                            </div>
                        </div>
                        <div className="col-md-7">
                            <label for="Description" className="form-label">Description</label>
                            <input type="text" value={Description} onChange={(e) => setDescription(e.target.value)} className="form-control" id="validationCustom02" placeholder="Description" name="Description" />

                            <div className="valid-feedback">
                                Looks good!
                            </div>
                        </div>
                        <div className="col-md-7">
                            <label for="File" className="form-label">File</label>
                            <input type="text" value={File} onChange={(e) => setFile(e.target.value)} className="form-control" id="validationCustom02" placeholder="File" name="File" />

                            <div className="valid-feedback">
                                Looks good!
                            </div>
                        </div>
                        <br />
                        <div className="col-12">
                            <button onClick={addLessonSubmit} className="btn btn-primary">Add Lesson</button>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    );
};

export default AddLesson;