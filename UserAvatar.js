import React from "react";
import { getAvatarById } from "./UserAvatarMultiplexer";
import Store from "./Store";
import { connect } from "react-redux";

class UserAvatar extends React.PureComponent {
  state = {
    userAvatar: null,
    userTypeId: null,
    fullName: null
  };

  componentDidMount = () => {
    getAvatarById(this.props.id).then(
      resp => {
        if (!this.unmounted){
        this.setState({
          userAvatar: resp.avatarUrl!=="Null"? resp.avatarUrl:"https://example.png",
          userTypeId: resp.userTypeId,
          fullName: resp.fullName
        }, ()=>console.log(this.state))}},
      err => console.error("Error getting user avatar.", err)
      );
  };

  componentWillUnmount(){
    this.unmounted = true;
  }

  render() {
    const userType =
      this.props.userTypes &&
      this.props.userTypes.find(element => element.id == this.state.userTypeId);
    return (
      <span className="UserAvatar">
        <img
          src={this.state.userAvatar}
          className={this.props.imageClass}
          alt="UserAvatar"
        />
        <span className="FullName">{this.state.fullName}</span>
        <span className="UserType">{userType && userType.name}</span>
      </span>
    );
  }
}

function mapStateToProps(state) {
  return {
    userTypes: state.lookupData ? state.lookupData.UserType : []
  };
}

export default connect(mapStateToProps, null)(UserAvatar);
