function getData(e) {
    class CommentBox extends React.Component {
        render() {
            return (
                <div className="commentBox">e.firstName, || e.lastName</div>
            );
        }
    }

    ReactDOM.render(<CommentBox />, document.getElementById('content'));
}
