CREATE TABLE surveys (
    id SERIAL PRIMARY KEY,
    title TEXT NOT NULL
);

CREATE TABLE questions (
    id SERIAL PRIMARY KEY,
    text TEXT NOT NULL,
    survey_id INT NOT NULL,
    FOREIGN KEY (survey_id) REFERENCES surveys(id) ON DELETE CASCADE
);

CREATE TABLE answers (
    id SERIAL PRIMARY KEY,
    text TEXT NOT NULL,
    question_id INT NOT NULL,
    FOREIGN KEY (question_id) REFERENCES questions(id) ON DELETE CASCADE
);

CREATE TABLE interviews (
    id SERIAL PRIMARY KEY,
    survey_id INT NOT NULL,
    started_at TIMESTAMP DEFAULT NOW(),
    completed_at TIMESTAMP NULL,
    FOREIGN KEY (survey_id) REFERENCES surveys(id) ON DELETE CASCADE
);

CREATE TABLE results (
    id SERIAL PRIMARY KEY,
    interview_id INT NOT NULL,
    question_id INT NOT NULL,
    answer_id INT NOT NULL,
    FOREIGN KEY (interview_id) REFERENCES interviews(id) ON DELETE CASCADE,
    FOREIGN KEY (question_id) REFERENCES questions(id) ON DELETE CASCADE,
    FOREIGN KEY (answer_id) REFERENCES answers(id) ON DELETE CASCADE
);

CREATE INDEX idx_questions_survey_id ON questions(survey_id);
CREATE INDEX idx_answers_question_id ON answers(question_id);
CREATE INDEX idx_results_interview_id ON results(interview_id);
CREATE INDEX idx_results_question_id ON results(question_id);
CREATE INDEX idx_results_answer_id ON results(answer_id);
